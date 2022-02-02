using LN.Application.DTOs.Address.Requests;
using LN.Application.DTOs.City.Requests;
using LN.Application.DTOs.Contact.Requests;
using LN.Application.DTOs.Country.Requests;
using LN.Application.DTOs.PhoneNumber.Requests;
using LN.Application.DTOs.State.Requests;
using LN.Core.Application.DTOs.Contact.Responses;
using LN.Core.Application.Wrappers;
using LN.Core.Domain.Entities;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.BaseTemplates
{
    public abstract class ContactBaseTemplate
    {
        public Contact _requestMapped;

        public Response<Contact> _responseContact;
        private Response<ContactDTO> _response = new Response<ContactDTO>();
        public IContactRepository _contactRepository;

        public NewContactDTO _contact;
        public NewPhoneNumberDTO _phoneNumber;
        public NewAddressDTO _address;
        public NewCountryDTO _country;
        public NewStateDTO _state;
        public NewCityDTO _city;

        public async Task<Response<ContactDTO>> TemplateMethod() {
            Setup();
            MapRequestBase();
            await HookCRUDOperation();
            MapResponseBase();

            return _response;
        }

        public virtual void Setup() { }

        public virtual void MapRequestBase() { }

        public virtual async Task HookCRUDOperation() { }

        public virtual void MapResponseBase() { }
    }
}
