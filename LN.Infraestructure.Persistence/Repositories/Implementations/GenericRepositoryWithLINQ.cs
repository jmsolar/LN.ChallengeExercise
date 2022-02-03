using LN.Core.Application.Wrappers;
using LN.Infraestructure.Persistence.Contexts;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LN.Infraestructure.Persistence.Repositories.Implementations
{
    public class GenericRepositoryWithLINQ<T> : IGenericRepository<T> where T : class
    {
        private readonly Response<T> _response;
        private readonly ApplicationContext _context;

        public GenericRepositoryWithLINQ(ApplicationContext context)
        {
            _context = context;
            _response = new Response<T>();
        }

        #region Not implemented methods
        public async Task<Response<T>> Update(string query, List<SqlParameter> parms)
        {
            throw new NotImplementedException();
        }
        #endregion

        /// <summary>
        /// Adds a entity to DB and return it
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Response<T>> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            _response.Data = entity;

            return _response;
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Response<T>> GetById(Guid Id)
        {
            _response.Data = await _context.Set<T>().FindAsync(Id);

            return _response;
        }

        /// <summary>
        /// Removes phisically a entity from DB and return if was success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Response<T>> Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            var result = await _context.SaveChangesAsync();

            if (result < 0) _response.Success = false;

            return _response;
        }
    }
}
