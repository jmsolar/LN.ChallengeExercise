using System;
using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.Contact
{
    [DataContract]
    public class ContactRequestDTO
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
        public string PhoneCountryCode { get; set; }
        [DataMember]
        public string PhoneStateCode { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string CountryName { get; set; }
        [DataMember]
        public int CountryNumericCode { get; set; }
        [DataMember]
        public string CountryAlphaCode { get; set; }
        [DataMember]
        public string StateCode { get; set; }
        [DataMember]
        public string StateName { get; set; }
        [DataMember]
        public int CityZipCode { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string CityDetail { get; set; }
    }
}
