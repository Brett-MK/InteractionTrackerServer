using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TalkDeskInterviewApp.Controllers;
using TalkDeskInterviewApp.Data;
using TalkDeskInterviewApp.Dtos;
using TalkDeskInterviewApp.Models;

namespace TalkDeskInterviewApp.Test
{
    [TestClass]
    public class CommandsControllerTest
    {
        private Mock<ICommandRepo> _mockRepo = new Mock<ICommandRepo>();
        private Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private CommandsController _commandsController;

        [TestInitialize]
        public void TestInitialize()
        {
            _commandsController = new CommandsController(_mockRepo.Object, _mockMapper.Object);
        }

        [TestMethod]
        public void GetAllCommand_ReturnsOkStatus()
        {
            var expectedCommands = new List<Command>();
            _mockRepo.Setup(x => x.GetAllCommands()).Returns(expectedCommands.AsQueryable());

            var response = _commandsController.GetAllCommands(null);

            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetCommandById_ReturnsOkStatus()
        {
            var expectedCommand = new Command();
            _mockRepo.Setup(x => x.GetCommandById(1)).Returns(Task.FromResult(expectedCommand));

            var response = await _commandsController.GetCommandById(1);

            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetCommandById_CommandDoesntExist_ReturnsNotFound()
        {
            _mockRepo.Setup(x => x.GetCommandById(It.IsAny<int>())).Returns(Task.FromResult((Command)null));

            var response = await _commandsController.GetCommandById(1);

            Assert.IsInstanceOfType(response.Result, typeof(NotFoundResult));
        }
    }
}
