using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.City.Responses
{
    [DataContract]
    public class CityDTO
    {
        [DataMember]
        public int ZipCode { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
