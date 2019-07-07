using System;
using System.Collections.Generic;
using System.Text;
using Core.Infrastructure.Application.Contract.DTO;
using Core.Infrastructure.Application.Contract.DTO.RefValue;

namespace Core.Infrastructure.Domain.Aggregate.RefTypeValue
{
    public class RefValueService : IRefValueService
    {
        public ResponseDTO<RefValueDTO> GetByKey(long key)
        {
         return new ResponseDTO<RefValueDTO>();
        }

        public ResponseDTO<RefValueDTO> Create(RefValueDTO DTO)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<RefValueDTO> Update(RefValueDTO DTO)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<RefValueDTO> Delete(RefValueDTO DTO)
        {
            throw new NotImplementedException();
        }
    }
}
