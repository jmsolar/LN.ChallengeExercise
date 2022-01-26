using System.Collections.Generic;

namespace LN.Core.Application.Wrappers
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public IList<Error> Errors { get; set; }

        public Response()
        {
            Success = true;
            Errors = new List<Error>();
        }
    }

    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
