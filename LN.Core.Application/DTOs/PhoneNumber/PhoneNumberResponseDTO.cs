using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.PhoneNumber
{
    [DataContract]
    public class PhoneNumberResponseDTO
    {
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string StateCode { get; set; }
        [DataMember]
        public string Number { get; set; }
    }
}
