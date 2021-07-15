using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/WeatherForecast")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ValuesHolder holder;
        public WeatherForecastController(ValuesHolder holder)
        {
            this.holder = holder;
        }
        [HttpPost("create")]
        public IActionResult Create([FromQuery] DateTime date, [FromQuery] int temperatureC)
        {
            var Values = holder.Values.Where(wf => wf.Date == date).ToArray();
            if (Values.Length != 0)
            {
                return BadRequest("Data already exists!");
            }

            var curWF = new WeatherForecast() { Date = date.Date, TemperatureC = temperatureC };
            holder.Values.Add(curWF);
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime date, [FromQuery] int temperatureC)
        {
            foreach (WeatherForecast wf in holder)
            {
                if (wf.Date == date)
                {
                    wf.TemperatureC = temperatureC;
                    return Ok();
                }                
            }
            return BadRequest("No data exists");
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime date)
        {
            holder.Values = holder.Values.Where(wf => wf.Date != date).ToList();
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(holder.Values);
        }
        [HttpGet("readPeriod")]
        public IActionResult ReadPeriod(DateTime dateFrom, DateTime dateTo)
        {
            var curValues = holder.Values.Where(wf => wf.Date >= dateFrom && wf.Date <= dateTo).ToArray();
            return Ok(curValues);
        }
    }
}