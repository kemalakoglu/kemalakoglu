using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Infrastructure.Application.Contract.DTO.RefType;
using Core.Infrastructure.Application.Contract.DTO.RefValue;

namespace Core.Infrastructure.Application.Contract.DTO.Blog
{
    [DataContract]
    public class GetHomeDataResponse
    {
        [DataMember]
        public IEnumerable<RefValueDTO> FeaturedPosts { get; set; }
        [DataMember]
        public IEnumerable<RefValueDTO> LatestPosts { get; set; }
        [DataMember]
        public IEnumerable<RefTypeDTO> Sections { get; set; }
    }
}
