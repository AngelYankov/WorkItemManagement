using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class GetTeam_Should
    {
        [TestMethod]
        public void GetTeam_Should_ReturnTeam()
        {
            var fakeData = new FakeDatabase();
            var teamToGet = new Team("Team1");
            fakeData.AddTeam(teamToGet);
            var team = Validator.GetTeam("Team1", fakeData);
            Assert.IsInstanceOfType(team, typeof(ITeam));
            Assert.AreEqual("Team1", teamToGet.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhen_TeamDoesNotExist()
        {
            var fakeData = new FakeDatabase();
            Validator.GetTeam("Team1", fakeData);
        }
    }
}
