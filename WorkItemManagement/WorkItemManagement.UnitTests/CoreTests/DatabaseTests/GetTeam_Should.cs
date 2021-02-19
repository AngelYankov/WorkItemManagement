using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class GetTeam_Should : CleanerDatabase
    {
        [TestMethod]
        public void ReturnsTeam()
        {
            var db = Database.Instance;
            var team = new FakeTeam();
            team.Name = "Team1";
            db.AddTeamToDB(team);

            var expected = db.GetTeam("Team1");
            Assert.AreEqual(team, expected);
        }

        [TestMethod]
        public void ThrowWhen_TeamDoesNotExist()
        {
            var db = Database.Instance;
            var result = Assert.ThrowsException<ArgumentException>(() => db.GetTeam("Team1"));
            Assert.AreEqual("Team: 'Team1' does not exist.", result.Message);
        }
    }
}
