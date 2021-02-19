using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class TeamExists_Should : TestBaseClass
    {
        [TestMethod]
        public void ThrowWhen_TeamExists()
        {
            var validator = new Validator(database);
            var team = new FakeTeam("Team1");
            validator.Database.AddTeamToDB(team);
            var result = Assert.ThrowsException<ArgumentException>(() => validator.TeamExists("Team1"));
            Assert.AreEqual("Team: 'Team1' already exists", result.Message);
            
        }
        
    }
}
