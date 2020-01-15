using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.Domain.Contract.Service
{
    public interface IUserStoreService
    {
        Task<IdentityResult> CreateAsync(IdentityUser user);
        Task<IdentityUser> GetUserByEmail(string requestEmail);
        Task<IdentityUser> FindByLoginAsync(string provider, string key);
        void SignInAsync(IdentityUser user, bool isPersistance);
        Task<SignInResult> PasswordSignInAsync(IdentityUser user, string password, bool isPErsistance,
            bool lockoutOnFailure);
        Task<Task> AddLoginAsync(IdentityUser appUser, UserLoginInfo userLoginInfo);
    }
}