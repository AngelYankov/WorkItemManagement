using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class GetAllTeams_Should
    {
        [TestMethod]
        public void ReturnsAllteams()
        {
            var db = Database.Instance;
            var teams = db.GetAllTeams();
            Assert.IsInstanceOfType(teams, typeof(IList<ITeam>));
        }
    }
}
