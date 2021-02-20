using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class ShowPersonActivityCommand_Should : TestBaseClass
    {
        [TestMethod]
        public void ShowPerson_ShowActivity()
        {
            var factory = new Mock<IFactory>();
            var result = new ShowPersonActivityCommand(new List<string>() { "Member1" }, database, factory.Object).Execute();
            Assert.AreEqual(result, string.Join("; ", database.GetMember("Member1").ActivityHistory));
        }
        
        [TestMethod]
        public void ShowPerson_NoActivity()
        {
            var factory = new Mock<IFactory>();
            var result = new ShowPersonActivityCommand(new List<string>() {"Member3" }, database, factory.Object).Execute();
            Assert.AreEqual(result, "No history added.");
        }

        
    }
}
