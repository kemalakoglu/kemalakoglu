using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Infrastructure.Domain.Contract.DTO.Base;

namespace Core.Infrastructure.Domain.Contract.DTO.RefValue
{
    [DataContract]
    public class AddRefValueRequestDTO : BaseDTO
    {
        [DataMember] public string Value { get; set; }
        [DataMember] public long RefTypeId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public bool IsActive { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public string Image { get; set; }
        [DataMember] public string ImageText { get; set; }

    }
}
