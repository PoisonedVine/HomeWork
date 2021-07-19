using System;
using Microsoft.AspNetCore.Mvc;
using MetricsManager.Controllers;
using Xunit;

namespace MetricsManager.Tests
{
    public class AgentControllerTests
    {
        private readonly AgentController agentController;
        public AgentControllerTests()
        {
            agentController = new AgentController();
        }

        [Fact]
        public void GetRegistredObjects_ReturnsOk()
        {
            var result = agentController.GetRegistredObjects();
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void RegisterAgent_ReturnsOk()
        {
            var testAgentInfo = new AgentInfo();
            var result = agentController.RegisterAgent(testAgentInfo);
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void EnableAgentById_ReturnsOk()
        {
            int agentId = 0;
            var result = agentController.EnableAgentById(agentId);
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void DisableAgentById_ReturnsOk()
        {
            int agentId = 0;
            var result = agentController.DisableAgentById(agentId);
            var isAssignableFrom = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}