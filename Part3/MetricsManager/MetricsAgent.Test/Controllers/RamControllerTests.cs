using System;
using Microsoft.AspNetCore.Mvc;
using MetricsAgent.Controllers;
using Xunit;

namespace MetricsAgent.Test
{
    public class RamControllerTests
    {
        [Fact]
        public void GetAvailableSpace_ReturnsOk()
        {
            var controller = new RamController();
            var result = controller.GetAvailableSpace();
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}