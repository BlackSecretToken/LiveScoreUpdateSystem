﻿using LiveScoreUpdateSystem.Services.Data.Contracts;
using LiveScoreUpdateSystem.Web.Areas.Admin.Controllers.Grids;
using LiveScoreUpdateSystem.Web.Areas.Admin.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace LiveScoreUpdateSystem.Web.Tests.Areas.Admin.Grids.PlayersGridControllerTests
{
    [TestFixture]
    public class DeletePlayer_Should
    {
        [Test]
        public void CallTeamServiceDeleteMethodWithCorrectId()
        {
            // arrange
            var teamService = new Mock<ITeamService>();
            var teamViewModel = new GridTeamViewModel() { Name = "someName", Id = Guid.NewGuid(), LogoUrl = "SomeLogo" };

            var controller = new TeamsGridController(teamService.Object);

            // act
            controller.DeleteTeam(teamViewModel);

            // assert
            teamService.Verify(c => c.Delete(teamViewModel.Id), Times.Once);
        }

        [Test]
        public void ReturnJsonArrayWithDeletedTeam_WhenPassedModelParamIsNotNull()
        {
            // arrange
            var teamService = new Mock<IPlayerService>();
            var playerViewModel = new GridPlayerViewModel() { FirstName = "someName" };
            var controller = new PlayersGridController(teamService.Object);

            // act
            controller.DeletePlayer(playerViewModel);

            // assert
            controller.WithCallTo(c => c.DeletePlayer(playerViewModel))
                .ShouldReturnJson((data) => Assert.AreSame(data[0], playerViewModel));
        }
    }
}
