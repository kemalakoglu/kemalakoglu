using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


using Core.Infrastructure.Application.Contract.Services;
using Core.Infrastructure.Domain.Contract.DTO.RefType;
using Core.Infrastructure.Presentation.API.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Core.Infrastructure.Presentation.API.Controllers
{
    public class RefTypeController : Controller
    {
        private readonly ICoreApplicationService appService;

        public RefTypeController(ICoreApplicationService appService)
        {
            this.appService = appService;
        }

        /// <summary>
        /// AddRefType
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/RefType/AddRefType")]
        [JwtAuthentication]
        [ServiceFilter(typeof(JWTRefreshTokenAttribute))]
        [HttpPost]
        public IActionResult AddRefType([FromBody]AddRefTypeRequestDTO request)
        {
            return Ok(this.appService.AddRefType(request));
        }

        /// <summary>
        /// Update Ref Type
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/RefType/UpdateRefType")]
        [JwtAuthentication]
        [ServiceFilter(typeof(JWTRefreshTokenAttribute))]
        [HttpPost]
        public IActionResult UpdateRefType([FromBody]RefTypeDTO request)
        {
            return Ok(this.appService.UpdateRefType(request));
        }

        /// <summary>
        /// GetRefTypesByParent
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/RefType/GetRefTypesByParent")]
        [JwtAuthentication]
        [ServiceFilter(typeof(JWTRefreshTokenAttribute))]
        [HttpGet]
        public IActionResult GetRefTypesByParent(long parentId)
        {
            return Ok(this.appService.GetRefTypesByParent(parentId));
        }

        /// <summary>
        /// GetRefTypesByParent
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/RefType/DeleteRefType")]
        [JwtAuthentication]
        [ServiceFilter(typeof(JWTRefreshTokenAttribute))]
        [HttpGet]
        public IActionResult DeleteRefType(long id)
        {
            return Ok(this.appService.DeleteRefType(id));
        }

        /// <summary>
        /// GetRefTypesByParent
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/RefType/SoftDeleteRefType")]
        [JwtAuthentication]
        [ServiceFilter(typeof(JWTRefreshTokenAttribute))]
        [HttpGet]
        public IActionResult SoftDeleteRefType(long id)
        {
            return Ok(this.appService.SoftDeleteRefType(id));
        }
    }
}
