using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Infrastructure.Domain.Contract.DTO.Base;

namespace Core.Infrastructure.Domain.Contract.DTO.RefValue
{
    [DataContract]
    public class AddRefValueResponseDTO : BaseDTO
    {
        [DataMember] public bool Succeed { get; set; }
    }
}
