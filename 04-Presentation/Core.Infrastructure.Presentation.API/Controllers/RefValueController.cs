using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Infrastructure.Application.Contract.Services;
using Core.Infrastructure.Domain.Aggregate.RefTypeValue;
using Core.Infrastructure.Domain.Contract.DTO.RefValue;
using Core.Infrastructure.Presentation.API.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Core.Infrastructure.Presentation.API.Controllers
{
    public class RefValueController: Controller
    {
        private readonly ICoreApplicationService appService;

        public RefValueController(ICoreApplicationService appService)
        {
            this.appService = appService;
        }

        /// <summary>
        /// GetRefTypesByParent
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/RefValue/GeRefValuesByRefTypeId")]
        [JwtAuthentication]
        [HttpGet]
        public IActionResult GeRefValuesByRefTypeId(long refTypeId)
        {
            return Ok(this.appService.GeRefValuesByRefTypeId(refTypeId));
        }

        /// <summary>
        /// AddRefValue
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/RefValue/AddRefValue")]
        [JwtAuthentication]
        [HttpPost]
        public IActionResult AddRefValue([FromBody] AddRefValueRequestDTO request)
        {
            return Ok(this.appService.AddRefValue(request));
        }

        /// <summary>
        /// GetRefValuesByPage
        /// </summary>
        /// <returns></returns>
        [Route("api/RefValue/GetRefValuesByPage")]
        [JwtAuthentication]
        [HttpGet]
        public IActionResult GetRefValuesByPage()
        {
            return Ok(this.appService.GetRefValuesByPage());
        }

        /// <summary>
        /// GetRefValuesByPage
        /// </summary>
        /// <returns></returns>
        [Route("api/RefValue/DeleteRefValue")]
        [JwtAuthentication]
        [HttpPost]
        public IActionResult DeleteRefValue([FromBody] RefValueDTO request)
        {
            return Ok(this.appService.DeleteRefValue(request));
        }

        [Route("api/RefValue/UpdateRefValue")]
        [JwtAuthentication]
        [HttpPost]
        public IActionResult UpdateRefValue([FromBody]RefValueDTO request)
        {
            return Ok(this.appService.UpdateRefValue(request));
        }

        /// <summary>
        /// GetRefValuesByPage
        /// </summary>
        /// <returns></returns>
        [Route("api/RefValue/SoftDeleteRefValue")]
        [JwtAuthentication]
        [HttpPost]
        public IActionResult SoftDeleteRefValue([FromBody] RefValueDTO request)
        {
            return Ok(this.appService.SoftDeleteRefValue(request));
        }
    }
}
