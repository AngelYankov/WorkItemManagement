using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Core;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class AddTeamToDB_Should
    {
        [TestMethod]
        public void Should_AddTeam()
        {
            var db = Database.Instance;
            var team = new FakeTeam();
            db.AddTeamToDB(team);

            Assert.IsTrue(db.AllTeams.Contains(team));
        }
    }
}
