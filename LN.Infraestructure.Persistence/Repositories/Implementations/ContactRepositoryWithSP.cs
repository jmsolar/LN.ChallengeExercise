using LN.Core.Application.Wrappers;
using LN.Core.Domain.Entities;
using LN.Infraestructure.Persistence.Contexts;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LN.Infraestructure.Persistence.Repositories.Implementations
{
    public class ContactRepositoryWithSP : GenericRepositoryWithSP<Contact>, IContactRepositoryWithSP
    {
        private readonly DbSet<Contact> _contacts;

        public ContactRepositoryWithSP(ApplicationContext context) : base(context)
        {
            _contacts = context.Set<Contact>();
        }

        public override async Task<Response<Contact>> GetById(Guid Id)
        {
            var response = new Response<Contact>();
            string query = "EXEC ApplicationDB.Contact_FindById @Id";
            List<SqlParameter> parameters = new List<SqlParameter>() {
                new SqlParameter() { ParameterName = "Id", Value = Id }
            };

            var contact = await _contacts.FromSqlRaw<Contact>(query, parameters.ToArray()).FirstOrDefaultAsync();
            response.Data = contact;

            return response;
        }
    }
}
