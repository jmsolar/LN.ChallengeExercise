using LN.Core.Application.Wrappers;
using LN.Infraestructure.Persistence.Contexts;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LN.Infraestructure.Persistence.Repositories.Implementations
{
    public class GenericRepositoryWithSP<T> : IGenericRepository<T> where T : class
    {
        private readonly Response<T> _response;
        private readonly ApplicationContext _context;

        public GenericRepositoryWithSP(ApplicationContext context)
        {
            _context = context;
            _response = new Response<T>();
        }

        #region Not implemented methods
        public async Task<Response<T>> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<T>> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<T>> Remove(T entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        /// <summary>
        /// Modifies a entity on DB and return if was success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Response<T>> Update(string query, List<SqlParameter> parameters)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw(query, parameters.ToArray());

            _response.Success = rowsAffected > 0;

            return _response;
        }
    }
}
