using LN.Core.Application.DTOs.Contact;
using LN.Core.Application.Wrappers;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace LN.Service.Interfaces
{
    [ServiceContract]
    public interface IContactService
    {
        /// <summary>
        /// Creates a contact and return it
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<Response<ContactResponseDTO>> CreateContact(ContactRequestDTO request);

        /// <summary>
        /// Retrieves a contact by Id field
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [OperationContract]
        Task<Response<ContactResponseDTO>> GetContactById(Guid Id);

        /// <summary>
        /// Modifies a contact on DB and return if was succesfull
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<Response<bool>> UpdateContact(ContactRequestDTO request);

        /// <summary>
        /// Removes a contact return if was succesfull
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [OperationContract]
        Task<Response<bool>> DeleteContact(ContactRequestDTO request);
    }
}
