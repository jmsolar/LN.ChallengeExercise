using LN.Core.Application.DTOs.Address.Responses;
using LN.Core.Application.DTOs.PhoneNumber.Responses;
using System;
using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.Contact.Responses
{
    [DataContract]
    public class ContactResponseDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Company { get; set; }
        [DataMember]
        public string Profile { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public DateTime Birthdate { get; set; }
        [DataMember]
        public PhoneNumberDTO PhoneNumber { get; set; }
        [DataMember]
        public AddressDTO Address { get; set; }
    }
}
