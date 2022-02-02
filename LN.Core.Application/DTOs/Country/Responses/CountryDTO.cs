using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.Country.Responses
{
    [DataContract]
    public class CountryDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int NumericCode { get; set; }
        [DataMember]
        public string AlphaCode { get; set; }
    }
}
