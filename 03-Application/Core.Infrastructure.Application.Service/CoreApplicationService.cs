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

        #region identity services

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="requestEmail">The request email.</param>
        /// <returns></returns>
        public async Task<IdentityUser> GetUserByEmail(string requestEmail) =>
            await this.userStoreService.GetUserByEmail(requestEmail);
        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateAsync(IdentityUser user) => await this.userStoreService.CreateAsync(user);

        /// <summary>
        /// Finds the by login asynchronous.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public async Task<IdentityUser> FindByLoginAsync(string provider, string key) =>
            await this.userStoreService.FindByLoginAsync(provider, key);

        /// <summary>
        /// Signs the in asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="isPersistance">if set to <c>true</c> [is persistance].</param>
        public void SignInAsync(IdentityUser user, bool isPersistance) =>
             this.userStoreService.SignInAsync(user, isPersistance);

        /// <summary>
        /// Passwords the sign in asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <param name="isPersistance">if set to <c>true</c> [is persistance].</param>
        /// <param name="lockoutOnFailure">if set to <c>true</c> [lockout on failure].</param>
        /// <returns></returns>
        public async Task<SignInResult> PasswordSignInAsync(IdentityUser user, string password, bool isPersistance,
            bool lockoutOnFailure) =>
            await this.userStoreService.PasswordSignInAsync(user, password, isPersistance, lockoutOnFailure);

        public async Task<Task> AddLoginAsync(IdentityUser appUser, UserLoginInfo userLoginInfo) =>
            await this.userStoreService.AddLoginAsync(appUser, userLoginInfo);

        #endregion
        #region RefTypeValue Aggregate

        /// <summary>
        /// Adds the type of the reference.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ResponseDTO<AddRefTypeResponseDTO> AddRefType(AddRefTypeRequestDTO request) => this.refTypeService.Create(request);

        /// <summary>
        /// Deletes the type of the reference.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ResponseDTO<RefTypeDTO> DeleteRefType(long id) => this.refTypeService.Delete(new RefTypeDTO { Id = id });

        /// <summary>
        /// Softs the type of the delete reference.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ResponseDTO<RefTypeDTO> SoftDeleteRefType(long id) => this.refTypeService.SoftDelete(id);

        /// <summary>
        /// Updates the type of the reference.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ResponseDTO<RefTypeDTO> UpdateRefType(RefTypeDTO request) => this.refTypeService.Update(request);

        /// <summary>
        /// Deletes the type of the reference.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ResponseDTO<RefTypeDTO> DeleteRefType(RefTypeDTO request) => this.refTypeService.Delete(request);

        /// <summary>
        /// Softs the type of the delete reference.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ResponseDTO<RefTypeDTO> SoftDeleteRefType(RefTypeDTO request) => this.refTypeService.SoftDelete(request.Id);

        /// <summary>
        /// Gets the reference types by parent.
        /// </summary>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns></returns>
        public ResponseListDTO<RefTypeDTO> GetRefTypesByParent(long parentId) => this.refTypeService.GetByParent(parentId);

        /// <summary>
        /// Ges the reference values by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public ResponseListDTO<RefValueDTO> GeRefValuesByRefTypeId(long refTypeId) => this.refValueService.GetByRefTypeId(refTypeId);

        /// <summary>
        /// Adds the reference value.
        /// </summary>
        /// <param name="refValue">The reference value.</param>
        /// <returns></returns>
        public ResponseDTO<AddRefValueResponseDTO> AddRefValue(AddRefValueRequestDTO refValue) => this.refValueService.Create(refValue);

        /// <summary>
        /// Gets the reference values by page.
        /// </summary>
        /// <returns></returns>
        public ResponseListDTO<RefValueDTO> GetRefValuesByPage() => this.refValueService.GetRefValuesByPage();

        /// <summary>
        /// Deletes the reference value.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ResponseDTO<RefValueDTO> DeleteRefValue(RefValueDTO request) => this.refValueService.Delete(request);

        /// <summary>
        /// Updates the reference value.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ResponseDTO<RefValueDTO> UpdateRefValue(RefValueDTO request) => this.refValueService.Update(request);

        /// <summary>
        /// Softs the delete reference value.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ResponseDTO<RefValueDTO> SoftDeleteRefValue(RefValueDTO request) => this.refValueService.SoftDelete(request.Id);

        /// <summary>
        /// Gets the home data.
        /// </summary>
        /// <returns></returns>
        public ResponseDTO<GetHomeDataResponse> GetHomeData()
        {
            GetHomeDataResponse response = new GetHomeDataResponse();
            IEnumerable<RefValueDTO> posts = this.refValueService.GetLastByNumber(5).Data;
            response.Sections = this.refTypeService.GetByParent(1).Data;
            response.LatestPosts = posts.Take(3);
            response.FeaturedPosts = posts.TakeLast(2);
            return CreateResponse<GetHomeDataResponse>.Return(response, "GetHomeData");
        }
        #endregion
    }
}
