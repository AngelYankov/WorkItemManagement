using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Commands;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CommandsTests
{
    [TestClass]
    public class AddCommentCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void AddComment_ReturnsCorrectOutput()
        {
            var factory = new Mock<IFactory>();
            var parameters = new List<string>() { "2", "Member1", "This is a comment." };
            var command = new AddCommentCommand(parameters,database,factory.Object);

            Assert.AreEqual("Member: 'Member1' added comment: 'This is a comment.' to work item: '2'", command.Execute());
        }
    }
}
