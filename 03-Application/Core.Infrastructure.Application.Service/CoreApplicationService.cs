using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Infrastructure.Application.Contract.DTO;
using Core.Infrastructure.Application.Contract.DTO.RefType;
using Core.Infrastructure.Application.Contract.DTO.RefValue;
using Core.Infrastructure.Application.Contract.Services;
using Core.Infrastructure.Domain.Aggregate.RefTypeValue;
using Core.Infrastructure.Domain.Contract.Service;
using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.Application.Service
{
    public class CoreApplicationService : ICoreApplicationService
    {
        private readonly IUserStoreService userStoreService;
        private readonly IRefTypeService refTypeService;
        private readonly IRefValueService refValueService;

        public CoreApplicationService(IUserStoreService userStoreService, IRefTypeService refTypeService, IRefValueService refvalueService)
        {
            this.userStoreService = userStoreService;
            this.refTypeService = refTypeService;
            this.refValueService = refvalueService;
        }
        public Task<IdentityUser> GetUserByMail(RegisterDTO request)
        {
            return this.userStoreService.GetUserByEmail(request.Email);
        }

#region RefTypeValue Aggregate
        public ResponseDTO<AddRefTypeResponseDTO> AddRefType(AddRefTypeRequestDTO request)
        {
            return this.refTypeService.Create(request);
        }

        public ResponseDTO<RefTypeDTO> DeleteRefType(long id)
        {
            return this.refTypeService.Delete(new RefTypeDTO {Id = id});
        }

        public ResponseDTO<RefTypeDTO> SoftDeleteRefType(long id)
        {
            return this.refTypeService.SoftDelete(id);
        }

        public ResponseDTO<RefTypeDTO> UpdateRefType(RefTypeDTO request)
        {
            return this.refTypeService.Update(request);
        }

        public ResponseDTO<RefTypeDTO> DeleteRefType(RefTypeDTO request)
        {
            return this.refTypeService.Delete(request);
        }

        public ResponseDTO<RefTypeDTO> SoftDeleteRefType(RefTypeDTO request)
        {
            return this.refTypeService.SoftDelete(request.Id);
        }

        public ResponseListDTO<RefTypeDTO> GetRefTypesByParent(long parentId)
        {
            return this.refTypeService.GetByParent(parentId);
        }

        public ResponseListDTO<RefValueDTO> GeRefValuesByRefTypeId(long refTypeId)
        {
            return this.refValueService.GetByRefTypeId(refTypeId);
        }

        public ResponseDTO<AddRefValueResponseDTO> AddRefValue(AddRefValueRequestDTO refValue)
        {
            return this.refValueService.Create(refValue);
        }

        public ResponseListDTO<RefValueDTO> GetRefValuesByPage()
        {
            return this.refValueService.GetRefValuesByPage();
        }

        public ResponseDTO<RefValueDTO> DeleteRefValue(RefValueDTO request)
        {
            return this.refValueService.Delete(request);
        }

        #endregion
    }
}
