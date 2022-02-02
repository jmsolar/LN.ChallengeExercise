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
using System;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.BaseTemplates
{
    public abstract class ContactBaseTemplate
    {
        public Contact _requestMapped;
        public Response<Contact> _responseContact;

        #region Data responses
        public Response<ContactDTO> _response = new Response<ContactDTO>();
        public Response<bool> _responseStatus;
        #endregion

        // REFACTOR! sacar la asignacion al momento de la instanciacion
        // Repositories
        public IContactRepository _contactRepository;

        #region Filters or data request to map
        public NewContactDTO _newContact;
        public NewPhoneNumberDTO _phoneNumber;
        public NewAddressDTO _address;
        public NewCountryDTO _country;
        public NewStateDTO _state;
        public NewCityDTO _city;
        public Guid _id;
        public ModifyContactDTO _modifyContact;
        #endregion

        public async Task<Response<ContactDTO>> GetContact() {
            Setup();
            MapRequestBase();
            await CRUDOperation();
            MapResponseBase();

            return _response;
        }

        public async Task<Response<bool>> GetStatusResult()
        {
            Setup();
            MapRequestBase();
            await CRUDOperation();
            MapResponseBase();

            return _responseStatus;
        }

        public virtual void Setup() { }

        public virtual void MapRequestBase() { }

        public virtual async Task CRUDOperation() { }

        public virtual void MapResponseBase() { }
    }
}
