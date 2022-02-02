using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.PhoneNumber.Responses
{
    [DataContract]
    public class PhoneNumberDTO
    {
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string StateCode { get; set; }
        [DataMember]
        public string Number { get; set; }
    }
}
