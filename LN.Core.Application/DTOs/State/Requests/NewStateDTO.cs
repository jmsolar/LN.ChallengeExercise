using LN.Application.DTOs.Generic;
using System.Runtime.Serialization;

namespace LN.Application.DTOs.State.Requests
{
    [DataContract]
    public class NewStateDTO : GenericDTO
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
