using LN.Core.Application.DTOs.City;
using LN.Core.Application.DTOs.Country;
using LN.Core.Application.DTOs.State;
using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.Address
{
    [DataContract]
    public class AddressResponseDTO
    {
        [DataMember]
        public CountryResponseDTO Country { get; set; }
        [DataMember]
        public StateResponseDTO State { get; set; }
        [DataMember]
        public CityResponseDTO City { get; set; }

        // Calle + numero + piso
        public string Detail { get; set; }
    }
}
