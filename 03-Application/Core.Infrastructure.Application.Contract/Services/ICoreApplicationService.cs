using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Infrastructure.Core.Helper;
using Core.Infrastructure.Domain.Aggregate.User;
using Core.Infrastructure.Domain.Contract.DTO.Blog;
using Core.Infrastructure.Domain.Contract.DTO.RefType;
using Core.Infrastructure.Domain.Contract.DTO.RefValue;
using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.Application.Contract.Services
{
    public interface ICoreApplicationService
    {
        #region RefType/RefValue
        /// <summary>
        /// Updates the type of the reference.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        ResponseDTO<RefTypeDTO> UpdateRefType(RefTypeDTO request);

        /// <summary>
        /// Gets the reference types by parent.
        /// </summary>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns></returns>
        ResponseListDTO<RefTypeDTO> GetRefTypesByParent(long parentId);

        /// <summary>
        /// Adds the type of the reference.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        ResponseDTO<AddRefTypeResponseDTO> AddRefType(AddRefTypeRequestDTO request);

        /// <summary>
        /// Deletes the type of the reference.
        /// </summary>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns></returns>
        ResponseDTO<RefTypeDTO> DeleteRefType(long parentId);

        /// <summary>
        /// Softs the type of the delete reference.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ResponseDTO<RefTypeDTO> SoftDeleteRefType(long id);

        /// <summary>
        /// Ges the reference values by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        ResponseListDTO<RefValueDTO> GetRefValuesByRefTypeId(long refTypeId);

        /// <summary>
        /// Adds the reference value.
        /// </summary>
        /// <param name="refValue">The reference value.</param>
        /// <returns></returns>
        ResponseDTO<AddRefValueResponseDTO> AddRefValue(AddRefValueRequestDTO refValue);

        /// <summary>
        /// Gets the reference values by page.
        /// </summary>
        /// <returns></returns>
        ResponseListDTO<RefValueDTO> GetRefValuesByPage();

        /// <summary>
        /// Deletes the reference value.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        ResponseDTO<RefValueDTO> DeleteRefValue(RefValueDTO request);

        /// <summary>
        /// Updates the reference value.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        ResponseDTO<RefValueDTO> UpdateRefValue(RefValueDTO request);

        /// <summary>
        /// Softs the delete reference value.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        ResponseDTO<RefValueDTO> SoftDeleteRefValue(RefValueDTO request);

        /// <summary>
        /// Gets the home data.
        /// </summary>
        /// <returns></returns>
        ResponseDTO<GetHomeDataResponseDTO> GetHomeData();

        /// <summary>
        /// Gets the reference value by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        ResponseDTO<GetRefValueByIdResponseDTO> GetRefValueById(long Id);

        /// <summary>
        /// Gets the reference value for blogs by reference type identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ResponseDTO<GetRefValueForBlogsByRefTypeIdResponseDTO> GetRefValueForBlogsByRefTypeId(long id);

        /// <summary>
        /// Gets the reference value for blogs by archive.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        ResponseDTO<GetRefValueForBlogsByArchiveResponseDTO> GetRefValueForBlogsByArchive(string year, string month);

        #endregion

        #region ApplicationUser

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="requestEmail">The request email.</param>
        /// <returns></returns>
        Task<ApplicationUser> GetUserByEmail(string requestEmail);

        /// <summary>
        /// Finds the by login asynchronous.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Task<ApplicationUser> FindByLoginAsync(string provider, string key);

        /// <summary>
        /// Signs the in asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="isPersistance">if set to <c>true</c> [is persistance].</param>
        /// <returns></returns>
        Task SignInAsync(ApplicationUser user, bool isPersistance);

        /// <summary>
        /// Passwords the sign in asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="isPersistance">if set to <c>true</c> [is persistance].</param>
        /// <param name="lockoutOnFailure">if set to <c>true</c> [lockout on failure].</param>
        /// <returns></returns>
        Task<SignInResult> PasswordSignInAsync(string email, string password, bool isPersistance,
            bool lockoutOnFailure);

        /// <summary>
        /// Adds the login asynchronous.
        /// </summary>
        /// <param name="appUser">The application user.</param>
        /// <param name="userLoginInfo">The user login information.</param>
        /// <returns></returns>
        Task<IdentityResult> AddLoginAsync(ApplicationUser appUser, UserLoginInfo userLoginInfo);

        /// <summary>
        /// Signs the out asynchronous.
        /// </summary>
        /// <returns></returns>
        Task SignOutAsync();

        /// <summary>
        /// Generates the user token asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ApplicationUser user,
            string token);

        /// <summary>
        /// Removes the login asynchronous.
        /// </summary>
        /// <param name="appUser">The application user.</param>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="providerKey">The provider key.</param>
        /// <returns></returns>
        Task<IdentityResult> RemoveLoginAsync(ApplicationUser appUser, string loginProvider, string providerKey);

        /// <summary>
        /// Removes the token asynchronous.
        /// </summary>
        /// <param name="appUser">The application user.</param>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="tokenName">Name of the token.</param>
        /// <returns></returns>
        Task<IdentityResult> RemoveAuthenticationTokenAsync(ApplicationUser appUser, string loginProvider,
            string tokenName);

        /// <summary>
        /// Refreshes the sign in asynchronous.
        /// </summary>
        /// <param name="appUser">The application user.</param>
        void RefreshSignInAsync(ApplicationUser appUser);

        #endregion
    }
}
