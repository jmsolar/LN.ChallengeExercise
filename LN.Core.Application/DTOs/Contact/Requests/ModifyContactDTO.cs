using LN.Application.DTOs.Address.Requests;
using LN.Application.DTOs.Generic;
using LN.Application.DTOs.PhoneNumber.Requests;
using System;
using System.Runtime.Serialization;

namespace LN.Application.DTOs.Contact.Requests
{
    [DataContract]
    public class ModifyContactDTO : GenericDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Company { get; set; }
        [DataMember]
        public string Profile { get; set; }
        [DataMember]
        public NewPhoneNumberDTO PhoneNumber { get; set; }
        [DataMember]
        public NewAddressDTO Address { get; set; }
    }
}
