using System;
using Microsoft.AspNetCore.Mvc;
using MetricsManager.Controllers;
using Xunit;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Tests
{
    public class CpuMetricsControllerTests
    {
        private readonly CpuMetricsController cpuMetricsController;
        public CpuMetricsControllerTests(ILogger<CpuMetricsController> logger)
        {
            cpuMetricsController = new CpuMetricsController(logger);
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            int agentId = 0;
            var fromTime = TimeSpan.Zero;
            var toTime = TimeSpan.Zero;

            var result = cpuMetricsController.GetMetricsFromAgent(agentId, fromTime, toTime);
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetMetricsFromAllCluster_ReturnsOk()
        {
            var fromTime = TimeSpan.Zero;
            var toTime = TimeSpan.Zero;

            var result = cpuMetricsController.GetMetricsFromAllCluster(fromTime, toTime);
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}