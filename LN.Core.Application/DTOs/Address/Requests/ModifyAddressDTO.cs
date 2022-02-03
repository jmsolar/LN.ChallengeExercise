using LN.Application.DTOs.City.Requests;
using LN.Application.DTOs.Country.Requests;
using LN.Application.DTOs.Generic;
using LN.Application.DTOs.State.Requests;
using System.Runtime.Serialization;

namespace LN.Application.DTOs.Address.Requests
{
    [DataContract]
    public class ModifyAddressDTO : GenericDTO
    {
        [DataMember]
        public ModifyCountryDTO Country { get; set; }
        [DataMember]
        public ModifyStateDTO State { get; set; }
        [DataMember]
        public ModifyCityDTO City { get; set; }
        [DataMember]
        public string Detail { get; set; }
    }
}
