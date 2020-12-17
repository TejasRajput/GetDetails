using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SystemInfoCommon.Interface;
using SystemInfoCommon.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SystemInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SystemInfoController : ControllerBase
    {
        private readonly ISystemInfoService _systemInfoService;

        public SystemInfoController(ISystemInfoService systemInfoService)
        {
            _systemInfoService = systemInfoService;
        }

        [HttpGet("{itemId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ItemDetails>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(406)]
        public async Task<IActionResult> ProcessSystemInfo(int itemId)
        {
            try
            {
                var response = await _systemInfoService.SystemProcess(itemId);
                if (response == null) return NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Items>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(406)]
        public async Task<IActionResult> GetsListOfItems()
        {
            var response = await _systemInfoService.GetItemAsync();

            if (response == null) return NotFound();

            return Ok(response);
        }
    }
}