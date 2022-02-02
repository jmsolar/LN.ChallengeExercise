using LN.Application.DTOs.Generic;
using System;
using System.Runtime.Serialization;

namespace LN.Application.DTOs.Contact.Requests
{
    [DataContract]
    public class RemoveContactDTO : GenericDTO
    {
        [DataMember]
        public Guid Id { get; set; }
    }
}
