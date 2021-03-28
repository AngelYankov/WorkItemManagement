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
    public class ShowAllTeamsCommand_Should : TestBaseClass
    {
        [TestMethod]
        public void ShowAllTeams_NoTeamsExist()
        {
            var factory = new Mock<IFactory>();
            database.AllTeams.Clear();
            var result = new ShowAllTeamsCommand(new List<string>(), database, factory.Object).Execute();
            Assert.AreEqual("There are no teams.", result);
        }
        
        [TestMethod]
        public void ShowAllTeams_ShowsAllTeams()
        {
            var factory = new Mock<IFactory>();
            var result = new ShowAllTeamsCommand(new List<string>(), database, factory.Object).Execute();
            Assert.AreEqual(result, string.Join(", ", database.AllTeams.Select(t => t.Name)));
        }
    }
}
