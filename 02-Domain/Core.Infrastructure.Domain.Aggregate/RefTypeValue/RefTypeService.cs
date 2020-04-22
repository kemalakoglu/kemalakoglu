using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;


using Core.Infrastructure.Core.Contract;
using Core.Infrastructure.Core.Helper;
using Core.Infrastructure.Core.Resources;
using Core.Infrastructure.Domain.Contract.DTO.RefType;
using Core.Infrastructure.Presentation.API.Extensions;

namespace Core.Infrastructure.Domain.Aggregate.RefTypeValue
{
    public class RefTypeService : IRefTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RefTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ResponseDTO<RefTypeDTO> GetByKey(long key)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<RefTypeDTO> Create(RefTypeDTO DTO)
        {
            throw new NotImplementedException();
        }

        public ResponseDTO<AddRefTypeResponseDTO> Create(AddRefTypeRequestDTO DTO)
        {
            var entity = new RefType(DateTime.Now, DTO.Name, true);
            if (DTO.Parent.Id > 0)
                entity.SetParent(this.unitOfWork.Repository<RefType>().GetByKey(DTO.Parent.Id));

            unitOfWork.Repository<RefType>().Create(entity);
            unitOfWork.EndTransaction();
            DTO.Id = entity.Id;
            return CreateResponse<AddRefTypeResponseDTO>.Return(mapper.Map(DTO,new AddRefTypeResponseDTO()), "Create");
        }

        public ResponseDTO<RefTypeDTO> Update(RefTypeDTO DTO)
        {
            var entity = unitOfWork.Repository<RefType>().GetByKey(DTO.Id);
            entity.Update(DTO.Name, DTO.IsActive, DateTime.Now);
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

        public ResponseDTO<RefTypeDTO> SoftDelete(long Id)
        {
            var childs = this.unitOfWork.Repository<RefValue>().Get(x => x.RefType.Id == Id).FirstOrDefault();
            if (childs!=null)
            {
                throw new BusinessException(ResponseMessage.HasChild,"RefType");
            }
            var entity = unitOfWork.Repository<RefType>().GetByKey(Id);
            entity.SetStatus(false);
            unitOfWork.Repository<RefType>().Update(entity);
            unitOfWork.EndTransaction();
            return CreateResponse<RefTypeDTO>.Return(mapper.Map<RefType,RefTypeDTO>(entity),"RefType Soft Delete");
        }

        public ResponseListDTO<RefTypeDTO> GetByParent(long parentId)
        {
            IEnumerable<RefType> entity;
            if (parentId>0)
                entity = unitOfWork.Repository<RefType>().Query().Filter(x => x.Parent.Id == parentId && x.Status==true).Get();
            else
                entity = unitOfWork.Repository<RefType>().Query().Filter(x => x.Parent.Id == null && x.Status == true).Get();

            unitOfWork.EndTransaction();

            //List<RefTypeDTO> response = new List<RefTypeDTO>();
            return CreateResponse<RefTypeDTO>.Return(mapper.Map<RefType[], IEnumerable<RefTypeDTO>>(entity.ToArray()), "GetByParent");
        }
    }
}