using LN.Application.DTOs.Contact.Requests;
using LN.Core.Application.DTOs.Contact.Responses;
using LN.Core.Application.Wrappers;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using LN.Service.Interfaces;
using LN.Service.Utils.TemplateMethods.Adapters;
using LN.Service.Utils.TemplateMethods.Extensions;
using System;
using System.Threading.Tasks;

namespace LN.Service.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IContactRepositoryWithLINQ _contactRepositoryWithLINQ;
        private readonly IContactRepositoryWithSP _contactRepositoryWithSP;

        public ContactService(IContactRepositoryWithLINQ contactRepositoryWithLINQ, 
            IContactRepositoryWithSP contactRepositoryWithSP)
        {
            _contactRepositoryWithLINQ = contactRepositoryWithLINQ;
            _contactRepositoryWithSP = contactRepositoryWithSP;
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
                _contactRepository = _contactRepositoryWithLINQ
            };

            return await ContactAdapter.New(createContact, request);
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
                _contactRepository = _contactRepositoryWithLINQ
            };

            return await ContactAdapter.Delete(removeContact, Id);
        }

        /// <summary>
        /// Finds a contact filter by Id 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Response<ContactDTO>> GetContactById(Guid Id)
        {
            var getContact = new FindContact()
            {
                _contactRepository = _contactRepositoryWithLINQ
            };

            return await ContactAdapter.FindById(getContact, Id);
        }

        /// <summary>
        /// Modifies a contact 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<bool>> UpdateContact(Guid Id, ModifyContactDTO request)
        {
            var updateContact = new UpdateContact()
            {
                _contactRepository = _contactRepositoryWithSP
            };

            return await ContactAdapter.Modify(updateContact, request, Id);
        }
    }
}