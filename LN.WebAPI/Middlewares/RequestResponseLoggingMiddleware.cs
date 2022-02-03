using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LN.WebAPI.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task Invoke(HttpContext context)
        {
            await _LogRequest(context);
            await _LogResponse(context);
        }

        #region Metodos privados
        private static string _ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            stream.Seek(0, SeekOrigin.Begin);
            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;
            do
            {
                readChunkLength = reader.ReadBlock(readChunk, 0, readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            }
            while (readChunkLength > 0);

            return textWriter.ToString();
        }
        #endregion

        private async Task _LogRequest(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                await using var requestStream = _recyclableMemoryStreamManager.GetStream();
                await context.Request.Body.CopyToAsync(requestStream);

                Log.Information("RQ: {NewLine} Schema: {Schema} Host: {Host} Path: {Path} QueryStr: {QueryStr} Body: {Body}",
                            Environment.NewLine,
                            context.Request.Scheme,
                            context.Request.Host,
                            context.Request.Path,
                            context.Request.QueryString,
                            _ReadStreamInChunks(requestStream));

                context.Request.Body.Position = 0;
            }
            catch (Exception ex)
            {
                Log.Error("ERROR RQ: ", ex.Message);
            }

        }

        private async Task _LogResponse(HttpContext context)
        {
            try
            {
                var originalBodyStream = context.Response.Body;
                await using var responseBody = _recyclableMemoryStreamManager.GetStream();
                context.Response.Body = responseBody;
                await _next(context);
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                Log.Information("RP: {NewLine} Schema: {Schema} Host: {Host} Path: {Path} QueryStr: {QueryStr} Body: {Body}",
                            Environment.NewLine,
                            context.Request.Scheme,
                            context.Request.Host,
                            context.Request.Path,
                            context.Request.QueryString,
                            text);

                await responseBody.CopyToAsync(originalBodyStream);
                context.Response.Body = originalBodyStream;
            }
            catch (Exception ex)
            {
                Log.Error("ERROR RP: ", ex.Message);
            }
        }
    }
}