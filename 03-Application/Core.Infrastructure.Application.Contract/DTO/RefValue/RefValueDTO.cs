using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Infrastructure.Application.Contract.DTO.Base;
using Core.Infrastructure.Application.Contract.DTO.RefType;

namespace Core.Infrastructure.Application.Contract.DTO.RefValue
{
    [DataContract]
    public class RefValueDTO : BaseDTO
    {
        [DataMember] public string Value { get; set; }
        [DataMember] public RefTypeDTO RefType { get; set; }
        [DataMember] public string Name { get; set; }
    }
}
