using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Core.Infrastructure.Application.Contract.DTO;
using Core.Infrastructure.Application.Contract.DTO.RefType;
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
            RefValue entity = new RefValue(DTO.Value, true, DateTime.Now, null, DTO.IsActive, this.uow.Repository<RefType>().GetByKey(DTO.RefTypeId), DTO.Name);
            this.uow.Repository<RefValue>().Create(entity);
            this.uow.EndTransaction();
            return CreateResponse<AddRefValueResponseDTO>.Return(new AddRefValueResponseDTO { Succeed = true }, "Create");
        }

        public ResponseListDTO<RefValueDTO> GetRefValuesByPage()
        {
            IEnumerable<RefValue> entityList =
                this.uow.Repository<RefValue>().Query().Filter(x => x.RefType.Parent.Id == 1).Get();
            this.uow.EndTransaction();

            return CreateResponse<RefValueDTO>.Return(Mapper.Map<RefValue[], RefValueDTO[]>(entityList.ToArray()),
                "GetRefValuesByPage");
        }

        public ResponseDTO<RefValueDTO> Update(RefValueDTO DTO)
        {
            RefValue entity = this.uow.Repository<RefValue>().GetByKey(DTO.Id);
            entity.Update(DTO.Name, DTO.IsActive,
                this.uow.Repository<RefType>().GetByKey(DTO.RefType.Id), DTO.Value);
            this.uow.Repository<RefValue>().Update(entity);
            this.uow.EndTransaction();
            DTO.UpdateDate = entity.UpdateDate;
            return CreateResponse<RefValueDTO>.Return(DTO, "Update RefValue");
        }

        public ResponseDTO<RefValueDTO> Delete(RefValueDTO DTO)
        {
            RefValue entity= this.uow.Repository<RefValue>().GetByKey(DTO.Id);
            this.uow.Repository<RefValue>().Delete(entity);
            this.uow.EndTransaction();
            return CreateResponse<RefValueDTO>.Return(DTO,
                "GetRefValuesByPage");
        }

        public ResponseDTO<RefValueDTO> SoftDelete(long Id)
        {
            RefValue entity = this.uow.Repository<RefValue>().GetByKey(Id);
            entity.SetStatus(false);
            this.uow.Repository<RefValue>().Update(entity);
            this.uow.EndTransaction();
            return CreateResponse<RefValueDTO>.Return(Mapper.Map<RefValueDTO>(entity),
                "GetRefValuesByPage");
        }

        public ResponseListDTO<RefValueDTO> GetByRefTypeId(long refTypeId)
        {
            var entity = this.uow.Repository<RefValue>().Query().Filter(x => x.RefType.Id == refTypeId).Get();
           
            return CreateResponse<RefValueDTO>.Return(Mapper.Map<RefValue[],RefValueDTO[]>(entity.ToArray()), "GetByRefTypeId");
        }
    }
}
