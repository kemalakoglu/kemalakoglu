using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


using Core.Infrastructure.Domain.Contract.DTO.RefType;
using Core.Infrastructure.Domain.Contract.DTO.RefValue;

namespace Core.Infrastructure.Domain.Contract.DTO.Blog
{
    [DataContract]
    public class GetHomeDataResponseDTO
    {
        [DataMember]
        public IEnumerable<RefValueDTO> FeaturedPosts { get; set; }
        [DataMember]
        public IEnumerable<RefValueDTO> LatestPosts { get; set; }
        [DataMember]
        public IEnumerable<RefTypeDTO> Sections { get; set; }
        [DataMember]
        public IEnumerable<ArchivesDTO> Archives { get; set; }
    }
}
