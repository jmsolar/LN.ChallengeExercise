using System.Runtime.Serialization;

namespace LN.Core.Application.DTOs.State.Responses
{
    [DataContract]
    public class StateDTO
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
