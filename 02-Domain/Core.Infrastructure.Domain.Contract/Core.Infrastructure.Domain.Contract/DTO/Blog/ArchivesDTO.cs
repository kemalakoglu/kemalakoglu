using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Infrastructure.Domain.Contract.DTO.Blog
{
    [DataContract]
    public class ArchivesDTO
    {
        [DataMember] public string Url { get; set; }
        [DataMember] public string Title { get; set; }
    }
}
