using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class AddMemberCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void AddMember_ReturnsCorrectOutput()
        {
            var factory = new Mock<IFactory>();
            var command = new AddMemberCommand(new List<string>() { "Member1", "Team1" }, database, factory.Object);
            Assert.AreEqual("Member: 'Member1' added to team: 'Team1'.", command.Execute());
        }

    }
}
