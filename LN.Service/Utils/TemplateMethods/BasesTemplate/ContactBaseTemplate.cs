using LN.Application.DTOs.Contact.Requests;
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

        #region Data responses
        public Response<ContactDTO> _response = new Response<ContactDTO>();
        public Response<bool> _responseStatus;
        #endregion

        public IGenericRepository<Contact> _contactRepository;

        #region Filters or data request to map
        public NewContactDTO _newContact;
        public ModifyContactDTO _modifyContact;
        public FilterContacByIdDTO _filterContacById;
        public Guid _id;
        #endregion

        public async Task<Response<ContactDTO>> GetContact() {
            Setup();
            MapRequest();
            await CRUDOperation();
            MapResponse();

            return _response;
        }

        public async Task<Response<bool>> GetStatusResult()
        {
            Setup();
            MapRequest();
            await CRUDOperation();
            MapResponse();

            return _responseStatus;
        }

        public virtual void Setup() { }

        public virtual void MapRequest() { }

        public virtual async Task CRUDOperation() { }

        public virtual void MapResponse() { }
    }
}
