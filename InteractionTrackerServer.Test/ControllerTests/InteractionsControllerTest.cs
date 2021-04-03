using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using InteractionTrackerServer.Controllers;
using InteractionTrackerServer.Data;
using InteractionTrackerServer.Dtos;
using InteractionTrackerServer.Models;
using InteractionTrackerServer.Dtos.CreateDtos;
using InteractionTrackerServer.Enums;
using InteractionTrackerServer.Dtos.ReadDtos;
using System;
using Microsoft.AspNetCore.SignalR;
using InteractionTrackerServer.Hubs;

namespace InteractionTrackerServer.ControllerTests
{
    [TestClass]
    public class InteractionsControllerTest
    {
        private Mock<IInteractionRepo> _mockRepo = new Mock<IInteractionRepo>();
        private Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private Mock<IHubContext<InteractionHub>> _mockHub = new Mock<IHubContext<InteractionHub>>();
        private InteractionsController _interactionsController;

        [TestInitialize]
        public void TestInitialize()
        {
            _interactionsController = new InteractionsController(_mockRepo.Object, _mockMapper.Object, _mockHub.Object);
        }

        [TestMethod]
        public void GetAllInteractions_ReturnsOkStatus()
        {
            _mockRepo.Setup(x => x.GetAllInteractions()).Returns(new List<Interaction>().AsQueryable());

            var response = _interactionsController.GetAllInteractions();

            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetInteractionById_ReturnsOkStatus()
        {
            _mockRepo.Setup(x => x.GetInteractionById("1")).Returns(Task.FromResult(new Interaction()));

            var response = await _interactionsController.GetInteractionById("1");

            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetInteractionById_InteractionDoesntExist_ReturnsNotFound()
        {
            _mockRepo.Setup(x => x.GetInteractionById(It.IsAny<string>())).Returns(Task.FromResult((Interaction)null));

            var response = await _interactionsController.GetInteractionById("1");

            Assert.IsInstanceOfType(response.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task CreateInteraction_ReturnsCreatedAtRouteStatus()
        {
            var expectedInteractionCreateDto = new InteractionCreateDto() { CallId = "NewCallId", CustomerStatus = CustomerStatus.VIP };
            var expectedInteraction = new Interaction() { CallId = expectedInteractionCreateDto.CallId, CustomerStatus = expectedInteractionCreateDto.CustomerStatus };
            var expectedInteractionReadDto = new InteractionReadDto() { CallId = expectedInteractionCreateDto.CallId, CustomerStatus = expectedInteractionCreateDto.CustomerStatus };
            _mockMapper.Setup(x => x.Map<InteractionCreateDto, Interaction>(expectedInteractionCreateDto)).Returns(expectedInteraction);
            _mockMapper.Setup(x => x.Map<Interaction, InteractionReadDto>(expectedInteraction)).Returns(expectedInteractionReadDto);

            var response = await _interactionsController.CreateInteraction(expectedInteractionCreateDto);

            Assert.IsInstanceOfType(response.Result, typeof(CreatedAtRouteResult));
        }

        [TestMethod]
        public async Task CreateInteraction_DuplicateCallId_ReturnsBadRequest()
        {
            var expectedInteractionCreateDto = new InteractionCreateDto() { CallId = "NewCallId", CustomerStatus = CustomerStatus.VIP };
            var expectedInteraction = new Interaction() { CallId = expectedInteractionCreateDto.CallId, CustomerStatus = expectedInteractionCreateDto.CustomerStatus };
            _mockMapper.Setup(x => x.Map<InteractionCreateDto, Interaction>(expectedInteractionCreateDto)).Returns(expectedInteraction);
            _mockRepo.Setup(x => x.SaveChanges()).Throws(new Exception());

            var response = await _interactionsController.CreateInteraction(expectedInteractionCreateDto);

            Assert.IsInstanceOfType(response.Result, typeof(BadRequestResult));
        }
    }
}
