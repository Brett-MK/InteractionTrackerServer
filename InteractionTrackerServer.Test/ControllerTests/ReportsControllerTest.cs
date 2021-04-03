using AutoMapper;
using InteractionTrackerServer.Controllers;
using InteractionTrackerServer.Data;
using InteractionTrackerServer.Dtos.CreateDtos;
using InteractionTrackerServer.Dtos.ReadDtos;
using InteractionTrackerServer.Enums;
using InteractionTrackerServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionTrackerServer.ControllerTests
{
    [TestClass]
    public class ReportsControllerTest
    {
        private Mock<IInteractionRepo> _mockRepo = new Mock<IInteractionRepo>();
        private Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private ReportsController _reportsController;

        [TestInitialize]
        public void TestInitialize()
        {
            _reportsController = new ReportsController(_mockRepo.Object, _mockMapper.Object);
        }

        [TestMethod]
        public void GetDailyReport_ReturnsOkStatus()
        {
            _mockRepo.Setup(x => x.GetAllInteractions()).Returns(new List<Interaction>().AsQueryable());

            var response = _reportsController.GetDailyReport();

            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
        }
    }
}
