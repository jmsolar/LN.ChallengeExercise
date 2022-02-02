using System.Runtime.Serialization;

namespace LN.Application.DTOs.PhoneNumber.Requests
{
    [DataContract]
    public class NewPhoneNumberDTO
    {
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string StateCode { get; set; }
        [DataMember]
        public string Number { get; set; }
    }
}
