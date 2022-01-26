using LN.Core.Application.DTOs.Contact;
using LN.Core.Application.Wrappers;
using LN.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace LN.Service.Implementations
{
    public class ContactService : IContactService
    {
        public Task<Response<ContactResponseDTO>> CreateContact(ContactRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteContact(ContactRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ContactResponseDTO>> GetContactById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateContact(ContactRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
