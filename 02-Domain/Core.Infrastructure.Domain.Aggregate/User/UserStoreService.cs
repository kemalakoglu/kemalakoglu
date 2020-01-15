using System.Threading.Tasks;
using Core.Infrastructure.Core.Contract;
using Core.Infrastructure.Domain.Aggregate.User;
using Core.Infrastructure.Domain.Contract.Service;
using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.Domain.Aggregate.User
{
    public class UserStoreService : IUserStoreService
    {
        private readonly SignInManager<IdentityUser> signInManager;
        //private readonly IUserStoreRepository userStoreRepository;
        private readonly IUnitOfWork uow;
        private readonly UserManager<IdentityUser> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStoreService"/> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public UserStoreService(IUnitOfWork uow, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            //this.userStoreRepository = userStoreRepository;
            this.uow = uow;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateAsync(IdentityUser user) => await this.userManager.CreateAsync(user);

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="requestEmail">The request email.</param>
        /// <returns></returns>
        public async Task<IdentityUser> GetUserByEmail(string requestEmail) => await this.userManager.FindByEmailAsync(requestEmail);

        /// <summary>
        /// Finds the by login asynchronous.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public async Task<IdentityUser> FindByLoginAsync(string provider, string key) => await this.userManager.FindByLoginAsync(provider, key);

        /// <summary>
        /// Signs the in asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="isPersistance">if set to <c>true</c> [is persistance].</param>
        public async void SignInAsync(IdentityUser user, bool isPersistance)
        {
            await signInManager.SignInAsync(user, isPersistance);
        }

        /// <summary>
        /// Passwords the sign in asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <param name="isPErsistance">if set to <c>true</c> [is p ersistance].</param>
        /// <param name="lockoutOnFailure">if set to <c>true</c> [lockout on failure].</param>
        /// <returns></returns>
        public async Task<SignInResult> PasswordSignInAsync(IdentityUser user, string password, bool isPErsistance, bool lockoutOnFailure) => await this.signInManager.PasswordSignInAsync(user, password, isPErsistance, lockoutOnFailure);

        /// <summary>
        /// Adds the login asynchronous.
        /// </summary>
        /// <param name="appUser">The application user.</param>
        /// <param name="userLoginInfo">The user login information.</param>
        /// <returns></returns>
        public async Task<Task> AddLoginAsync(IdentityUser appUser, UserLoginInfo userLoginInfo) =>
            this.userManager.AddLoginAsync(appUser, userLoginInfo);
    }
}