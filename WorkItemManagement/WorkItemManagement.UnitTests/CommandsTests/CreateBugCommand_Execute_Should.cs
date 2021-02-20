using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class CreateBugCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void CreateBug_CreateSuccesfully()
        {
            var factory = new Mock<IFactory>();
            var result = new CreateBugCommand(new List<string>() { "Team1", "Board1", "5", "Bug Title", "low", "minor", "one-two-three", "This is the description" },
                database,factory.Object).Execute();
            Assert.AreEqual("Created bug: 'Bug Title' with id: '5'. Added to board: 'Board1' in team: 'Team1'", result);
        }
    }
}
