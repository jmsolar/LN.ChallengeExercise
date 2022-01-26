using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.City
{
    [DataContract]
    public class CityResponseDTO
    {
        [DataMember]
        public int ZipCode { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
