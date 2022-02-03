using LN.Application.DTOs.Contact.Requests;
using LN.Core.Application.DTOs.Contact.Responses;
using LN.Core.Application.Wrappers;
using LN.Service.Utils.TemplateMethods.BaseTemplates;
using LN.Service.Utils.TemplateMethods.Extensions;
using System;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.Adapters
{
    public static class ContactAdapter
    {
        private static ContactBaseTemplate _template;

        public static async Task<Response<ContactDTO>> New(CreateContact createContact, NewContactDTO request) {
            _template = createContact;
            _template._newContact = request;

            return await _template.GetContact();
        }

        public static async Task<Response<bool>> Delete(RemoveContact removeContact, Guid Id)
        {
            _template = removeContact;
            _template._id = Id;

            return await _template.GetStatusResult();
        }

        public static async Task<Response<bool>> Modify(UpdateContact updateContact, ModifyContactDTO request, Guid Id)
        {
            _template = updateContact;
            _template._id = Id;
            _template._modifyContact = request;

            return await _template.GetStatusResult();
        }

        public static async Task<Response<ContactDTO>> FindById(FindContact findContact, Guid Id) {
            _template = findContact;
            _template._id = Id;

            return await _template.GetContact();
        }
    }
}
