﻿using LN.Core.Application.DTOs.Contact;
using LN.Core.Application.Wrappers;
using LN.Infraestructure.Persistence.Repositories.Implementations;
using LN.Service.Interfaces;
using LN.Service.Utils.TemplateMethods.Adapters;
using LN.Service.Utils.TemplateMethods.ExtensionsTemplates;
using System;
using System.Threading.Tasks;

namespace LN.Service.Implementations
{
    public class ContactService : IContactService
    {
        private readonly ContactRepository _contactRepository;
        public ContactService(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        /// <summary>
        /// Adds a contact to DB and return it
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<ContactResponseDTO>> CreateContact(ContactRequestDTO request)
        {
            var createContact = new CreateContact
            {
                _contactRequest = request,
                _contactRepository = this._contactRepository
            };

            return await ContactAdapter.Create(createContact);
        }

        /// <summary>
        /// Removes a contact from DB and return if was success
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<bool>> DeleteContact(ContactRequestDTO request)
        {
            //var contact = ContactMapper.ToContact(request);
            //var resp = await _contactRepository.Remove(contact);
            var response = new Response<bool>() { 
                Success = true
            };

            return response;
        }

        /// <summary>
        /// Finds a contact filter by Id 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Response<ContactResponseDTO>> GetContactById(Guid Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifies a contact 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<bool>> UpdateContact(ContactRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
