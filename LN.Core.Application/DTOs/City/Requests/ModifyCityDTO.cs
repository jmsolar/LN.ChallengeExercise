﻿using LN.Application.DTOs.Generic;
using System.Runtime.Serialization;

namespace LN.Application.DTOs.City.Requests
{
    [DataContract]
    public class ModifyCityDTO : GenericDTO
    {
        [DataMember]
        public int ZipCode { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
