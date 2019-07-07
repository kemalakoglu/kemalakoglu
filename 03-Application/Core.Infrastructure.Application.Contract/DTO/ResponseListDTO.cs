﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Infrastructure.Application.Contract.DTO
{
    [DataContract]
    public class ResponseListDTO<T> where T: class
    {
        [DataMember]
        public IEnumerable<T> Data { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Information Information { get; set; }
        [DataMember]
        public string RC { get; set; }
    }
}
