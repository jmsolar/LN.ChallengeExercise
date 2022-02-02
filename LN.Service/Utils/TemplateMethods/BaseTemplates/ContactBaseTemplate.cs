using LN.Application.NewFolder.Implementations;
using LN.Application.NewFolder.Interfaces;
using LN.Core.Application.DTOs.Contact.Responses;
using LN.Core.Application.Wrappers;
using LN.Core.Domain.Entities;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.BaseTemplates
{
    public abstract class ContactBaseTemplate
    {
        public IMapContactRequest<MapContactRequest> _contactRequest;



        public Contact _contact;
        public Response<Contact> _responseContact;
        private Response<ContactResponseDTO> _response = new Response<ContactResponseDTO>();
        public IContactRepository _contactRepository;

        public async Task<Response<ContactResponseDTO>> TemplateMethod() {
            MapRequestBase();
            await HookCRUDOperation();
            MapResponseBase();

            return _response;
        }

        protected void MapRequestBase()
        {
            _contact = ContactMapper.ToContact(_contactRequest);
        }

        public virtual async Task HookCRUDOperation() { }

        protected void MapResponseBase()
        {
            _response.Data = ContactMapper.ToContactResponse(_responseContact.Data);
        }
    }
}
