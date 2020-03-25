using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Infrastructure.Domain.Contract.DTO.RefType;
using Core.Infrastructure.Domain.Contract.DTO.RefValue;

namespace Core.Infrastructure.Domain.Contract.DTO.Blog
{
    [DataContract]
    public class GetRefValueByIdResponseDTO
    {
        [DataMember] public RefValueDTO Content { get; set; }

        [DataMember] public IEnumerable<RefTypeDTO> Sections { get; set; }
    }
}
