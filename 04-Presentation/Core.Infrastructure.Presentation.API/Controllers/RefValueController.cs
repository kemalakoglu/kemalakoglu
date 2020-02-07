﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Infrastructure.Application.Contract.Services;
using Core.Infrastructure.Domain.Aggregate.RefTypeValue;
using Core.Infrastructure.Domain.Contract.DTO.RefValue;
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
        [HttpPost]
        public IActionResult DeleteRefValue([FromBody] RefValueDTO request)
        {
            return Ok(this.appService.DeleteRefValue(request));
        }

        [Route("api/RefValue/UpdateRefValue")]
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
        [HttpPost]
        public IActionResult SoftDeleteRefValue([FromBody] RefValueDTO request)
        {
            return Ok(this.appService.SoftDeleteRefValue(request));
        }
    }
}
