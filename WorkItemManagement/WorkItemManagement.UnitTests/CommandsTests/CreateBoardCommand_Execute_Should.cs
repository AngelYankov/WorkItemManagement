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
    public class CreateBoardCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void CreateBoard_CreatedSuccesfully()
        {
            var factory = new Mock<IFactory>();
            var result = new CreateBoardCommand(new List<string>() { "Board15", "Team1" }, database, factory.Object).Execute();
            Assert.AreEqual("Created board: 'Board15' in team: 'Team1'", result);

        }
    }
}
