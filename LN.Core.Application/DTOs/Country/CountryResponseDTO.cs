using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.Country
{
    [DataContract]
    public class CountryResponseDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int NumericCode { get; set; }
        [DataMember]
        public string AlphaCode { get; set; }
    }
}
