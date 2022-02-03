using LN.Core.Domain.Entities;
using LN.Infraestructure.Persistence.Contexts;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LN.Infraestructure.Persistence.Repositories.Implementations
{
    public class ContactRepositoryWithSP : GenericRepositoryWithSP<Contact>, IContactRepositoryWithSP
    {
        private readonly DbSet<Contact> _contacts;

        public ContactRepositoryWithSP(ApplicationContext context) : base(context)
        {
            _contacts = context.Set<Contact>();
        }
    }
}
