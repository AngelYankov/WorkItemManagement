using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class CreateTeamCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void CreateTeam_Successfully()
        {
            var factory = new Mock<IFactory>();
            var result = new CreateTeamCommand(new List<string>() { "Team5" }, database, factory.Object).Execute();
            Assert.AreEqual("Created team: 'Team5'.", result);
        }
    }
}
