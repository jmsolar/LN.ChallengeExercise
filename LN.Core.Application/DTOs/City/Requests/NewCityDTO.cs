using System.Runtime.Serialization;

namespace LN.Application.DTOs.City.Requests
{
    [DataContract]
    public class NewCityDTO
    {
        [DataMember]
        public int ZipCode { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
