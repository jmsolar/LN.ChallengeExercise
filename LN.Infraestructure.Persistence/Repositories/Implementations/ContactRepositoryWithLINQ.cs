using LN.Core.Domain.Entities;
using LN.Infraestructure.Persistence.Contexts;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LN.Infraestructure.Persistence.Repositories.Implementations
{
    public class ContactRepositoryWithLINQ : GenericRepositoryWithLINQ<Contact>, IContactRepositoryWithLINQ
    {
        private readonly DbSet<Contact> _contacts;

        public ContactRepositoryWithLINQ(ApplicationContext context) : base(context)
        {
            _contacts = context.Set<Contact>();
        }
    }
}
