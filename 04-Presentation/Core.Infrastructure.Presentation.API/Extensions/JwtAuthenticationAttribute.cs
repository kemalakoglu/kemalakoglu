using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Core.Infrastructure.Application.Contract.Services;
using Core.Infrastructure.Application.Service;
using Core.Infrastructure.Domain.Aggregate.User;
using Core.Infrastructure.Domain.Contract.DTO.Login;
using Core.Infrastructure.Presentation.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Core.Infrastructure.Presentation.API.Extensions
{
    public class JwtAuthenticationAttribute : Attribute, IFilterFactory
    {
        // Implement IFilterFactory
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new InternalAddHeaderFilter();
        }

        public bool IsReusable { get; }

        public static bool ValidateToken(string token)
        {
            return CheckToken(token) != string.Empty;
        }

        private static string CheckToken(string token)
        {
            var username = string.Empty;


            GetTokenInformation(token, out username);
            return username;
        }

        private static void GetTokenInformation(string token, out string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            LoginResponseDTO tokenData = JsonConvert.DeserializeObject<LoginResponseDTO>(token);
            var jwtToken = tokenHandler.ReadToken(tokenData.Token) as JwtSecurityToken;
            if (jwtToken.Subject == tokenData.Username)
                username = jwtToken.Subject;
            else
                username = String.Empty;
        }

        private class InternalAddHeaderFilter : IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext context)
            {
                var controller = (Controller)context.Controller;
                var key = controller.Request.Headers.ToArray().FirstOrDefault(x => x.Key == "Authorization").Value
                    .ToString().Replace("Bearer ", "");

                if (!ValidateToken(key)) throw new Exception("JWT Token is invalid. Token is: " + key);
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
               
            }
        }
    }
}