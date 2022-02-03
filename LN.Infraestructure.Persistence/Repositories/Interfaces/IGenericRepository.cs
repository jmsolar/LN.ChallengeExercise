using LN.Core.Application.Wrappers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LN.Infraestructure.Persistence.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Adds a entity to DB and return it
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Response<T>> Add(T entity);

        /// <summary>
        /// Retrieves a entity by Id field
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Response<T>> GetById(Guid Id);

        /// <summary>
        /// Modifies a entity on DB and return if was success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Response<T>> Update(string query, List<SqlParameter> parameters);

        /// <summary>
        /// Removes a entity from DB and return if was success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Response<T>> Remove(T entity);
    }
}
