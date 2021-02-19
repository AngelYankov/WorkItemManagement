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
    public class CreateMemberCommand_Execute_Should : TestBaseClass
    {
        [TestMethod]
        public void CreateMember_CreateSuccesfully()
        {
            var factory = new Mock<IFactory>();
            var result = new CreateMemberCommand(new List<string>() { "Member5" },database,factory.Object).Execute();
            Assert.AreEqual("Created member: 'Member5'",result);
        }
    }
}
