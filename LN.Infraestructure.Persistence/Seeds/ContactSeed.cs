using LN.Core.Domain.Entities;
using LN.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LN.Infraestructure.Persistence.Seeds
{
    public class ContactSeed : IEntityTypeConfiguration<Contact>
    {
        private EntityTypeBuilder<Contact> _builder;

        private void Seed()
        {
            
            
        }
        private void Agrego()
        {
            
            
        }
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            _builder = builder;
            //Seed();
        }
    }
}
