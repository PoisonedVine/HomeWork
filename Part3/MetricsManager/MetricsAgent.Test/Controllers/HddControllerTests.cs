using System;
using Microsoft.AspNetCore.Mvc;
using MetricsAgent.Controllers;
using Xunit;

namespace MetricsAgent.Test
{
    public class HddControllerTests
    {
        [Fact]
        public void GetHDDLeft_ReturnsOk()
        {

            var controller = new HddController();
            var result = controller.GetHDDLeft();
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}