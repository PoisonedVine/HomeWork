using System;
using Microsoft.AspNetCore.Mvc;
using MetricsAgent.Controllers;
using Xunit;

namespace MetricsAgent.Test
{
    public class CpuControllerTests
    {
        [Fact]
        public void GetCpuPerc_returnsOk()
        {
            var fromTime = TimeSpan.Zero;
            var toTime = TimeSpan.Zero;
            int percentile = 0;

            var controller = new CpuController();
            var result = controller.GetCpuPerc(fromTime, toTime, percentile);
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetCpu_returnsOk()
        {
            var fromTime = TimeSpan.Zero;
            var toTime = TimeSpan.Zero;

            var controller = new CpuController();
            var result = controller.GetCpu(fromTime, toTime);
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}