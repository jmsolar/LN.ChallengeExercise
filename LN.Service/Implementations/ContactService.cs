using LN.Application.DTOs.Contact.Requests;
using LN.Core.Application.DTOs.Contact.Responses;
using LN.Core.Application.Wrappers;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using LN.Service.Interfaces;
using LN.Service.Utils.TemplateMethods.Adapters;
using LN.Service.Utils.TemplateMethods.ExtensionsTemplates;
using System;
using System.Threading.Tasks;

namespace LN.Service.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        /// <summary>
        /// Adds a contact to DB and return it
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<ContactDTO>> CreateContact(NewContactDTO request)
        {
            var createContact = new CreateContact
            {
                _contactRepository = this._contactRepository
            };

            return await ContactAdapter.Create(createContact, request);
        }

        /// <summary>
        /// Removes a contact from DB and return if was success
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Response<bool>> DeleteContact(Guid Id)
        {
            var removeContact = new RemoveContact()
            {
                _contactRepository = this._contactRepository
            };

            return await ContactAdapter.Remove(removeContact, Id);
        }

        /// <summary>
        /// Finds a contact filter by Id 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Response<ContactDTO>> GetContactById(Guid Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifies a contact 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<bool>> UpdateContact(Guid Id, NewContactDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
