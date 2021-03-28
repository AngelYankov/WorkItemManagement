using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class AssignCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void AssignCommand_AssignMemberToWorkItem()
        {
            var factory = new Mock<IFactory>();
            var command = new AssignCommand(new List<string>() { "Member1", "2" }, database, factory.Object);
            Assert.AreEqual("Work item: '2' assigned to 'Member1'.", command.Execute());
        }
    }
}
