using System;
using Microsoft.AspNetCore.Mvc;
using MetricsAgent.Controllers;
using Xunit;

namespace MetricsAgent.Test
{
    public class DotNetControllerTests
    {
        [Fact]
        public void GetDotNetErrorCount_ReturnsOk()
        {
            var fromTime = TimeSpan.Zero;
            var toTime = TimeSpan.Zero;

            var controller = new DotNetController();
            var result = controller.GetDotNetErrorCount(fromTime, toTime);
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}