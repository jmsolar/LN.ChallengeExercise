using LN.Application.DTOs.Contact.Requests;
using LN.Core.Application.Wrappers;
using LN.Service.Utils.TemplateMethods.BaseTemplates;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.ExtensionMethod
{
    public class RemoveContact : ContactBaseTemplate
    {
        private RemoveContactDTO _contactToRemove;

        public override void Setup()
        {
            _contactToRemove = new RemoveContactDTO() { Id = _id };
        }

        public override async Task CRUDOperation()
        {
            var contactInDB = await _contactRepository.GetById(_contactToRemove.Id);

            if (contactInDB == null || contactInDB.Data == null)
                _responseStatus = new Response<bool>() { Success = false };

            var result = await _contactRepository.Remove(contactInDB.Data);
            _responseStatus = new Response<bool>() { Success = result.Success }; ;
        }
    }
}
