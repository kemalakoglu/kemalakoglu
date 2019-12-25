using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Infrastructure.Application.Contract.DTO.Base;

namespace Core.Infrastructure.Application.Contract.DTO.RefValue
{
    [DataContract]
    public class AddRefValueRequestDTO : BaseDTO
    {
        [DataMember] public string Value { get; set; }
        [DataMember] public long RefTypeId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public bool IsActive { get; set; }
    }
}
