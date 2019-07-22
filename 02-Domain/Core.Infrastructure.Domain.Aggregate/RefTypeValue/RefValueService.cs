using System;
using System.Collections.Generic;
using System.Linq;
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

        public ResponseDTO<AddRefValueResponseDTO> Create(AddRefValueRequestDTO DTO)
        {
            RefValue entity = new RefValue(DTO.Value, true, DateTime.Now, null, true, this.uow.Repository<RefType>().Query().Filter(x => x.Id == DTO.RefTypeId).Get().FirstOrDefault());
            this.uow.Repository<RefValue>().Create(entity);
            this.uow.EndTransaction();
            return CreateResponse<AddRefValueResponseDTO>.Return(new AddRefValueResponseDTO { Succeed = true }, "Create");
        }

        public ResponseDTO<RefValueDTO> Update(RefValueDTO DTO)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<RefValueDTO> Delete(RefValueDTO DTO)
        {
            throw new NotImplementedException();
        }

        public ResponseListDTO<RefValueDTO> GetByRefTypeId(long refTypeId)
        {
            var entity = this.uow.Repository<RefValue>().Query().Filter(x => x.RefType.Id == refTypeId).Get();
            List<RefValueDTO> response = new List<RefValueDTO>();
            foreach (var refValue in entity)
            {
                var responseItem = new RefValueDTO
                {
                    Id = refValue.Id,
                    InsertDate = refValue.InsertDate,
                    UpdateDate = refValue.UpdateDate,
                    IsActive = refValue.IsActive,
                    Value = refValue.Value
                };
                response.Add(responseItem);
            }

            return CreateResponse<RefValueDTO>.Return(response, "GetByRefTypeId");
        }
    }
}
