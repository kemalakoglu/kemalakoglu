using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Infrastructure.Application.Contract.DTO;
using Core.Infrastructure.Application.Contract.DTO.Blog;
using Core.Infrastructure.Application.Contract.DTO.RefType;
using Core.Infrastructure.Application.Contract.DTO.RefValue;
using Core.Infrastructure.Application.Contract.Services;
using Core.Infrastructure.Core.Helper;
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

        public Task<IdentityUser> GetUserByMail(RegisterDTO request) =>
            this.userStoreService.GetUserByEmail(request.Email);

        #region RefTypeValue Aggregate
        
        public ResponseDTO<AddRefTypeResponseDTO> AddRefType(AddRefTypeRequestDTO request) => this.refTypeService.Create(request);
        
        public ResponseDTO<RefTypeDTO> DeleteRefType(long id) => this.refTypeService.Delete(new RefTypeDTO {Id = id});
        
        public ResponseDTO<RefTypeDTO> SoftDeleteRefType(long id) => this.refTypeService.SoftDelete(id);
        
        public ResponseDTO<RefTypeDTO> UpdateRefType(RefTypeDTO request) => this.refTypeService.Update(request);
        
        public ResponseDTO<RefTypeDTO> DeleteRefType(RefTypeDTO request) => this.refTypeService.Delete(request);
        
        public ResponseDTO<RefTypeDTO> SoftDeleteRefType(RefTypeDTO request) => this.refTypeService.SoftDelete(request.Id);
        
        public ResponseListDTO<RefTypeDTO> GetRefTypesByParent(long parentId) => this.refTypeService.GetByParent(parentId);
        
        public ResponseListDTO<RefValueDTO> GeRefValuesByRefTypeId(long refTypeId) => this.refValueService.GetByRefTypeId(refTypeId);
        
        public ResponseDTO<AddRefValueResponseDTO> AddRefValue(AddRefValueRequestDTO refValue) => this.refValueService.Create(refValue);
        
        public ResponseListDTO<RefValueDTO> GetRefValuesByPage() => this.refValueService.GetRefValuesByPage();
        
        public ResponseDTO<RefValueDTO> DeleteRefValue(RefValueDTO request) => this.refValueService.Delete(request);
        
        public ResponseDTO<RefValueDTO> UpdateRefValue(RefValueDTO request) => this.refValueService.Update(request);

        public ResponseDTO<RefValueDTO> SoftDeleteRefValue(RefValueDTO request) => this.refValueService.SoftDelete(request.Id);
        public ResponseDTO<GetHomeDataResponse> GetHomeData()
        {
            GetHomeDataResponse response= new GetHomeDataResponse();
            IEnumerable<RefValueDTO> posts = this.refValueService.GetLastByNumber(5).Data;
            response.Sections =  this.refTypeService.GetByParent(1).Data;
            response.LatestPosts = posts.Take(3);
            response.FeaturedPosts = posts.TakeLast(2);
            return CreateResponse<GetHomeDataResponse>.Return(response, "GetHomeData");
        }

        #endregion
    }
}
