using LN.Service.Utils.TemplateMethods.BaseTemplates;
using System.Threading.Tasks;

namespace LN.Service.Utils.TemplateMethods.ExtensionsTemplates
{
    public class CreateContact : ContactBaseTemplate
    {
        public override async Task HookCRUDOperation() {
            _responseContact = await _contactRepository.Add(_contact);
        }
    }
}
