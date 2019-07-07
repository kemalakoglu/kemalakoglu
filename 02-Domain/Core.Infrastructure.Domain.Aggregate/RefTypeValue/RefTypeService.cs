using System;
using System.Collections.Generic;
using AutoMapper;
using Core.Infrastructure.Application.Contract.DTO;
using Core.Infrastructure.Application.Contract.DTO.RefType;
using Core.Infrastructure.Core.Contract;
using Core.Infrastructure.Core.Helper;

namespace Core.Infrastructure.Domain.Aggregate.RefTypeValue
{
    public class RefTypeService : IRefTypeService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RefTypeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ResponseDTO<RefTypeDTO> GetByKey(long key)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<RefTypeDTO> Create(RefTypeDTO DTO)
        {
            var entity = new RefType(DTO.Status, DTO.InsertDate, DTO.Name, DTO.IsActive);
            if (DTO.ParentId > 0) entity.SetParent(unitOfWork.Repository<RefType>().GetByKey(DTO.ParentId));
            unitOfWork.Repository<RefType>().Create(entity);
            unitOfWork.EndTransaction();
            return CreateResponse<RefTypeDTO>.Return(DTO, "Create");
        }

        public ResponseDTO<RefTypeDTO> Update(RefTypeDTO DTO)
        {
            var entity = unitOfWork.Repository<RefType>().GetByKey(DTO.Id);
            entity.Update(DTO.Status, DTO.Name, DTO.IsActive, DTO.UpdateDate);
            unitOfWork.Repository<RefType>().Update(entity);
            unitOfWork.EndTransaction();
            return CreateResponse<RefTypeDTO>.Return(DTO, "Update");
        }

        public ResponseDTO<RefTypeDTO> Delete(RefTypeDTO DTO)
        {
            var entity = unitOfWork.Repository<RefType>().GetByKey(DTO.Id);
            unitOfWork.Repository<RefType>().Delete(entity);
            unitOfWork.EndTransaction();
            return CreateResponse<RefTypeDTO>.Return(DTO, "Delete");
        }

        public ResponseListDTO<RefTypeDTO> GetByParent(long? parentId)
        {
            IEnumerable<RefType> entity;
            if (parentId > 0)
                entity = unitOfWork.Repository<RefType>().Query().Filter(x => x.Parent.Id == parentId.Value).Get();
            else
                entity = unitOfWork.Repository<RefType>().Query().Filter(x => x.Parent == null).Get();

            unitOfWork.EndTransaction();
            var response = new List<RefTypeDTO>();
            foreach (var refType in entity)
            {
                var responseItem = new RefTypeDTO
                {
                    Id = refType.Id,
                    InsertDate = refType.InsertDate,
                    UpdateDate = refType.UpdateDate,
                    IsActive = refType.IsActive,
                    Name = refType.Name
                };

                response.Add(responseItem);
            }
            //var response = mapper.Map(entity, new List<RefTypeDTO>());

            return CreateResponse<RefTypeDTO>.Return(response, "GetByParent");
        }
    }
}