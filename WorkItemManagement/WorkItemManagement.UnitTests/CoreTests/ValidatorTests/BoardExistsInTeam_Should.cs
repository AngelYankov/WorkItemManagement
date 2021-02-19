using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class BoardExistsInTeam_Should : TestBaseClass
    {
        [TestMethod]
        public void ThrowWhen_BoardExists()
        {
            var validator = new Validator(database);
            var team = new FakeTeam("Team1");
            team.AddBoard(new FakeBoard("Board1"));
            var result = Assert.ThrowsException<ArgumentException>(() => validator.BoardExistsInTeam("Board1", team));
            Assert.AreEqual("Board: 'Board1' already exists in team: 'Team1'", result.Message);
        }
    }
}
