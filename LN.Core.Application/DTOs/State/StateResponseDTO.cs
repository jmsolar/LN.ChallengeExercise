using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.State
{
    [DataContract]
    public class StateResponseDTO
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
