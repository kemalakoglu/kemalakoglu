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

        /// <summary>
        /// Initializes a new instance of the <see cref="RefValueService"/> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        public RefValueService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Gets the by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public ResponseDTO<RefValueDTO> GetByKey(long key)
        {
            return CreateResponse<RefValueDTO>.Return(Mapper.Map(this.uow.Repository<RefValue>().GetByKey(key), new RefValueDTO()), "GetByKey");
        }

        /// <summary>
        /// Creates the specified dto.
        /// </summary>
        /// <param name="DTO">The dto.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ResponseDTO<RefValueDTO> Create(RefValueDTO DTO)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the specified dto.
        /// </summary>
        /// <param name="DTO">The dto.</param>
        /// <returns></returns>
        public ResponseDTO<AddRefValueResponseDTO> Create(AddRefValueRequestDTO DTO)
        {
            RefValue entity = new RefValue(DTO.Value, true, DateTime.Now, null, DTO.IsActive, this.uow.Repository<RefType>().GetByKey(DTO.RefTypeId), DTO.Name);
            this.uow.Repository<RefValue>().Create(entity);
            this.uow.EndTransaction();
            return CreateResponse<AddRefValueResponseDTO>.Return(new AddRefValueResponseDTO { Succeed = true }, "Create");
        }

        /// <summary>
        /// Gets the reference values by page.
        /// </summary>
        /// <returns></returns>
        public ResponseListDTO<RefValueDTO> GetRefValuesByPage()
        {
            IEnumerable<RefValue> entityList =
                this.uow.Repository<RefValue>().Query().Filter(x => x.RefType.Parent.Id == 1).Get();
            this.uow.EndTransaction();

            return CreateResponse<RefValueDTO>.Return(Mapper.Map<RefValue[], RefValueDTO[]>(entityList.ToArray()),
                "GetRefValuesByPage");
        }

        /// <summary>
        /// Gets the last by number.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        public ResponseListDTO<RefValueDTO> GetLastByNumber(int i)
        {
            IEnumerable<RefValue> entityList =
                this.uow.Repository<RefValue>().Query().Filter(x => x.RefType.Parent.Id == 1).Get().TakeLast(i);
            this.uow.EndTransaction();

            return CreateResponse<RefValueDTO>.Return(Mapper.Map<RefValue[], RefValueDTO[]>(entityList.ToArray()),
                "GetLastByNumber");
        }

        /// <summary>
        /// Updates the specified dto.
        /// </summary>
        /// <param name="DTO">The dto.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes the specified dto.
        /// </summary>
        /// <param name="DTO">The dto.</param>
        /// <returns></returns>
        public ResponseDTO<RefValueDTO> Delete(RefValueDTO DTO)
        {
            RefValue entity= this.uow.Repository<RefValue>().GetByKey(DTO.Id);
            this.uow.Repository<RefValue>().Delete(entity);
            this.uow.EndTransaction();
            return CreateResponse<RefValueDTO>.Return(DTO,
                "GetRefValuesByPage");
        }

        /// <summary>
        /// Softs the delete.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public ResponseDTO<RefValueDTO> SoftDelete(long Id)
        {
            RefValue entity = this.uow.Repository<RefValue>().GetByKey(Id);
            entity.SetStatus(false);
            this.uow.Repository<RefValue>().Update(entity);
            this.uow.EndTransaction();
            return CreateResponse<RefValueDTO>.Return(Mapper.Map<RefValueDTO>(entity),
                "GetRefValuesByPage");
        }

        /// <summary>
        /// Gets the by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public ResponseListDTO<RefValueDTO> GetByRefTypeId(long refTypeId)
        {
            var entity = this.uow.Repository<RefValue>().Query().Filter(x => x.RefType.Id == refTypeId).Get();
           
            return CreateResponse<RefValueDTO>.Return(Mapper.Map<RefValue[],RefValueDTO[]>(entity.ToArray()), "GetByRefTypeId");
        }
    }
}
