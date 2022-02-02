using LN.Application.DTOs.Contact.Requests;
using LN.Application.Mappers.Interfaces;
using LN.Core.Application.DTOs.Contact.Responses;

namespace LN.Infraestructure.Persistence.Repositories.Interfaces
{
    public interface INewContactRequest : IMapContactRequest<NewContactDTO, ContactDTO>
    {
    }
}
