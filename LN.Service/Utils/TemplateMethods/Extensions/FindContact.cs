using LN.Application.DTOs.Contact.Requests;
using LN.Service.Utils.TemplateMethods.BaseTemplates;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.Extensions
{
    public class FindContact : ContactBaseTemplate
    {
        private FilterContacByIdDTO _request;

        public override void Setup()
        {
            _request = _filterContacById;
        }

        public override async Task CRUDOperation()
        {
            await _contactRepository.GetById(_request.Id);
        }

        public override void MapRequest()
        {
            base.MapRequest();
        }

        public override void MapResponse()
        {
            base.MapResponse();
        }


    }
}
