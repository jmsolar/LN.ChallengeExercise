using LN.Core.Application.Wrappers;
using LN.Infraestructure.Persistence.Contexts;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LN.Infraestructure.Persistence.Repositories.Implementations
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly Response<T> _response;
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a entity to DB and return it
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Response<T>> Add(T entity) {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            _response.Data = entity;

            return _response;
        }

        /// <summary>
        /// Retrieves a entity by Id field
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Response<T>> GetById(Guid Id) {
            _response.Data = await _context.Set<T>().FindAsync(Id); 

            return _response;
        }

        /// <summary>
        /// Modifies a entity on DB and return if was success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Response<T>> Update(T entity) {
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();

            if (result < 0) _response.Success = false;

            return _response;
        }

        /// <summary>
        /// Removes phisically a entity from DB and return if was success
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Response<T>> Remove(T entity) {
            _context.Set<T>().Remove(entity);
            var result = await _context.SaveChangesAsync();

            if (result < 0) _response.Success = false;

            return _response;
        }
    }
}
