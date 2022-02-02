using LN.Core.Application.DTOs.City.Responses;
using LN.Core.Application.DTOs.Country.Responses;
using LN.Core.Application.DTOs.State.Responses;
using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.Address.Responses
{
    [DataContract]
    public class AddressDTO
    {
        [DataMember]
        public CountryDTO Country { get; set; }
        [DataMember]
        public StateDTO State { get; set; }
        [DataMember]
        public CityDTO City { get; set; }

        // Calle + numero + piso
        public string Detail { get; set; }
    }
}
