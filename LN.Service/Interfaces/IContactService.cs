using LN.Application.DTOs.Contact.Requests;
using LN.Core.Application.DTOs.Contact.Responses;
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
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        Task<Response<ContactDTO>> CreateContact(NewContactDTO request);

        /// <summary>
        /// Retrieves a contact by Id field
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [OperationContract]
        Task<Response<ContactDTO>> GetContactById(Guid Id);

        /// <summary>
        /// Modifies a contact on DB and return if was succesfull
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"
        /// <returns></returns>
        [OperationContract]
        Task<Response<bool>> UpdateContact(Guid Id, ModifyContactDTO request);

        /// <summary>
        /// Removes a contact return if was succesfull
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [OperationContract]
        Task<Response<bool>> DeleteContact(Guid Id);
    }
}
