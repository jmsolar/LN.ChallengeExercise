using LN.Core.Application.DTOs.Contact;
using LN.Core.Application.Wrappers;
using LN.Core.Domain.Entities;
using LN.Infraestructure.Persistence.Repositories.Implementations;
using LN.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace LN.Service.Implementations
{
    public class ContactService : IContactService
    {
        private readonly ContactRepository _contactRepository;
        private readonly Response<ContactResponseDTO> _response;
        public ContactService(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _response = new Response<ContactResponseDTO>();
        }

        public async Task<Response<ContactResponseDTO>> CreateContact(ContactRequestDTO request)
        {
            // mapeo el request
            var contact = new Contact();
            var response = await _contactRepository.Add(contact);
            // mapeo el response

            return _response;
        }

        public async Task<Response<bool>> DeleteContact(ContactRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ContactResponseDTO>> GetContactById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> UpdateContact(ContactRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
