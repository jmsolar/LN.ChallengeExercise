using LN.Application.DTOs.Contact.Requests;
using LN.Core.Application.DTOs.Contact.Responses;
using LN.Core.Application.Wrappers;
using LN.Service.Utils.TemplateMethods.BaseTemplates;
using LN.Service.Utils.TemplateMethods.ExtensionsTemplates;
using System;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.Adapters
{
    public static class ContactAdapter
    {
        private static ContactBaseTemplate _template;
        public static NewContactDTO _request;

        public static async Task<Response<ContactDTO>> Create(CreateContact createContact, NewContactDTO request) {
            _template = createContact;

            _template._phoneNumber = request.PhoneNumber;
            _template._address = request.Address;
            _template._country = request.Address.Country;
            _template._state = request.Address.State;
            _template._city = request.Address.City;
            _template._newContact = request;

            return await _template.GetContact();
        }

        public static async Task<Response<bool>> Remove(RemoveContact removeContact, Guid Id)
        {
            _template = removeContact;

            _template._id = Id;

            return await _template.GetStatusResult();
        }
    }
}
