using LN.Core.Application.DTOs.Address;
using LN.Core.Application.DTOs.PhoneNumber;
using System;
using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.Contact
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
        public PhoneNumberResponseDTO PhoneNumber { get; set; }
        [DataMember]
        public AddressResponseDTO Address { get; set; }
    }
}
