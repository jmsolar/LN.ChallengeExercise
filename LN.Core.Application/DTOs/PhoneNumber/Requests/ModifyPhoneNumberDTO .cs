using LN.Application.DTOs.Generic;
using System.Runtime.Serialization;

namespace LN.Application.DTOs.PhoneNumber.Requests
{
    [DataContract]
    public class ModifyPhoneNumberDTO : GenericDTO
    {
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string StateCode { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public bool IsPersonal { get; set; }
    }
}
