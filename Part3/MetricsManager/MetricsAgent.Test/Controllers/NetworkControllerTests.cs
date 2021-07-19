using System;
using Microsoft.AspNetCore.Mvc;
using MetricsAgent.Controllers;
using Xunit;

namespace MetricsAgent.Test
{
    public class NetworkControllerTests
    {
        [Fact]
        public void GetNetworkParams_ReturnsOk()
        {
            var fromTime = TimeSpan.Zero;
            var toTime = TimeSpan.Zero;

            var controller = new NetworkController();
            var result = controller.GetNetworkParams(fromTime, toTime);
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}