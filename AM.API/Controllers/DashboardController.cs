using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AM.API.Services.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Dashboard")]
    public class DashboardController : BaseController
    {
        private readonly IDashboardService _service;
        public DashboardController(IDashboardService service
                                   )
        {
            _service = service;


        }
        
        [HttpGet]
        [Route("activity")]
        public IActionResult GetActivity()
        {
            var response = _service.Activity();
            return Ok(response);       
        }


        [HttpGet]
        [Route("totalrecords")]
        public IActionResult TotalNumbers()
        {
            var response = _service.TotalNumbers();
            return Ok(response);
        }

        [HttpGet]
        [Route("charts")]
        public IActionResult TotalChartNumbers()
        {
            var response = _service.TotalChartNumbers();
            return Ok(response);
        }

    }
}