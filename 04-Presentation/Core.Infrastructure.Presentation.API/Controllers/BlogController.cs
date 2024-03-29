﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Infrastructure.Application.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.Infrastructure.Presentation.API.Controllers
{
    public class BlogController:Controller
    {
        private readonly ICoreApplicationService appService;

        public BlogController(ICoreApplicationService appService)
        {
            this.appService = appService;
        }

        /// <summary>
        /// Gets the home data.
        /// </summary>
        /// <returns></returns>
        [Route("api/Blog/GetHomeData")]
        [HttpGet]
        public IActionResult GetHomeData()
        {
            return Ok(this.appService.GetHomeData());
        }


        /// <summary>
        /// Gets the home data.
        /// </summary>
        /// <returns></returns>
        [Route("api/Blog/GetById")]
        [HttpGet]
        public IActionResult GetById(long Id)
        {
            return Ok(this.appService.GetRefValueById(Id));
        }

        /// <summary>
        /// Ges the reference values by reference type identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [Route("api/Blog/GetRefValueForBlogsByRefTypeId")]
        [HttpGet]
        public IActionResult GetRefValueForBlogsByRefTypeId(long Id)
        {
            return Ok(this.appService.GetRefValueForBlogsByRefTypeId(Id));
        }

        [Route("api/Blog/GetRefValueForBlogsByArchive")]
        [HttpGet]
        public IActionResult GetRefValueForBlogsByArchive(string Year, string Month)
        {
            return Ok(this.appService.GetRefValueForBlogsByArchive(Year,Month));
        }
    }
}
