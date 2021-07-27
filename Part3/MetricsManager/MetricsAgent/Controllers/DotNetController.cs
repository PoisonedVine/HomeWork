using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetController : ControllerBase
    {
        private readonly ILogger _logger;

        public DotNetController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet("error-count/{fromTime}/to/{toTime}")]
        public IActionResult GetDotNetErrorCount([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"fromTime: {fromTime.ToString()} toTime: {toTime.ToString()}");
            return Ok();
        }
    }
}