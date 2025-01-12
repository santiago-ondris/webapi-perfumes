using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MasterNet.WebApi.Controllers
{
    [ApiController]
    [Route("Demo")]
    public class DemoController : ControllerBase
    {
        [HttpGet("getstring")]
        public string GetNombre()
        {
            return "santiondris.com";
        }
    }
}