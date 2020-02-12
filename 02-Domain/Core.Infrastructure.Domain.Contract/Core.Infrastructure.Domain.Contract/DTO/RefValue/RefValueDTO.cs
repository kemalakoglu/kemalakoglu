using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Infrastructure.Domain.Contract.DTO.Base;
using Core.Infrastructure.Domain.Contract.DTO.RefType;

namespace Core.Infrastructure.Domain.Contract.DTO.RefValue
{
    [DataContract]
    public class RefValueDTO : BaseDTO
    {
        [DataMember] public string Value { get; set; }
        [DataMember] public RefTypeDTO RefType { get; set; }
        [DataMember] public string Name { get; set; }
    }
}
