using LN.Core.Application.DTOs.Contact.Responses;
using LN.Core.Application.Wrappers;
using LN.Service.Utils.TemplateMethods.BaseTemplates;
using LN.Service.Utils.TemplateMethods.ExtensionsTemplates;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.Adapters
{
    public static class ContactAdapter
    {
        private static ContactBaseTemplate _template;

        public static async Task<Response<ContactResponseDTO>> Create(CreateContact createContact) {
            _template = createContact;

            return await _template.TemplateMethod();
        }
    }
}
