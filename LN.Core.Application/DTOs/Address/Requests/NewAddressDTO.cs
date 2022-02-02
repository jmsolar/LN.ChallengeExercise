using LN.Application.DTOs.City.Requests;
using LN.Application.DTOs.Country.Requests;
using LN.Application.DTOs.State.Requests;
using System.Runtime.Serialization;

namespace LN.Application.DTOs.Address.Requests
{
    [DataContract]
    public class NewAddressDTO
    {
        [DataMember]
        public NewCountryDTO Country { get; set; }
        [DataMember]
        public NewStateDTO State { get; set; }
        [DataMember]
        public NewCityDTO City { get; set; }
        [DataMember]
        public string Detail { get; set; }
    }
}
