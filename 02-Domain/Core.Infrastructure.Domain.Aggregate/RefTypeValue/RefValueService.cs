using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core.Infrastructure.Application.Contract.DTO;
using Core.Infrastructure.Application.Contract.DTO.RefValue;
using Core.Infrastructure.Core.Contract;
using Core.Infrastructure.Core.Helper;

namespace Core.Infrastructure.Domain.Aggregate.RefTypeValue
{
    public class RefValueService : IRefValueService
    {
        private readonly IUnitOfWork uow;

        public RefValueService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public ResponseDTO<RefValueDTO> GetByKey(long key)
        {
            return CreateResponse<RefValueDTO>.Return(Mapper.Map(this.uow.Repository<RefValue>().GetByKey(key), new RefValueDTO()), "GetByKey");
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
