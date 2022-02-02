﻿using System.Runtime.Serialization;

namespace LN.Application.DTOs.Country.Requests
{
    [DataContract]
    public class NewCountryDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int NumericCode { get; set; }
        [DataMember]
        public string AlphaCode { get; set; }
    }
}
