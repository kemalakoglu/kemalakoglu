using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Core.Infrastructure.Application.Contract.Services;
using Core.Infrastructure.Application.Service;
using Core.Infrastructure.Domain.Aggregate.User;
using Core.Infrastructure.Domain.Contract.DTO.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.Infrastructure.Presentation.API.Extensions
{
    public class JWTRefreshTokenAttribute : IActionFilter
    {
        public readonly ICoreApplicationService appService;

        public JWTRefreshTokenAttribute() { }

        public JWTRefreshTokenAttribute(ICoreApplicationService appService)
        {
            this.appService = appService;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = (Controller)context.Controller;
            var key = controller.Request.Headers.ToArray().FirstOrDefault(x => x.Key == "Authorization").Value
                .ToString().Replace("Bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();
            LoginResponseDTO tokenData = JsonConvert.DeserializeObject<LoginResponseDTO>(key);
            ApplicationUser appUser = Task.FromResult(this.appService.GetUserByEmail(tokenData.Username)).Result.Result;
            this.appService.RefreshSignInAsync(appUser);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //todo
        }
    }
}
