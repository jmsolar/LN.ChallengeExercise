using LN.Application.DTOs.Contact.Requests;
using LN.Application.NewFolder.Interfaces;

namespace LN.Infraestructure.Persistence.Repositories.Interfaces
{
    public interface INewContactRequest : IMapContactRequest<NewContactDTO>
    {
    }
}
