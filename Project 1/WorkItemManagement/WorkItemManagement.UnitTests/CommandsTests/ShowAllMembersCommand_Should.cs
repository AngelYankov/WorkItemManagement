using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class ShowAllMembersCommand_Should : TestBaseClass
    {
        [TestMethod]
        public void ShowAllMembers_NoMembersExist()
        {
            var factory = new Mock<IFactory>();
            database.AllMembers.Clear();
            var result = new ShowAllMembersCommand(new List<string>(), database, factory.Object).Execute();
            Assert.AreEqual("There are no members.", result);
        }
        
        [TestMethod]
        public void ShowAllMembers_ShowAllMembers()
        {
            var factory = new Mock<IFactory>();
            var result = new ShowAllMembersCommand(new List<string>(), database, factory.Object).Execute();
            Assert.AreEqual(result, string.Join(", ", database.GetAllMembers().Select(b => b.Name)));
        }
    }
}
