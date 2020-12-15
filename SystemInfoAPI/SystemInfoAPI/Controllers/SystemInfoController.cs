using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SystemInfoCommon.Interface;
using SystemInfoCommon.Model;
using Microsoft.AspNetCore.Mvc;

namespace SystemInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemInfoController : ControllerBase
    {
        private readonly ISystemInfoService _systemInfoService;

        public SystemInfoController(ISystemInfoService systemInfoService)
        {
            _systemInfoService = systemInfoService;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SystemType>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(406)]
        public async Task<IActionResult> ProcessSystemInfo(SystemType systemType)
        {
            try
            {
                var response = await _systemInfoService.SystemProcess(systemType.SelectedItem);

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