using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class BoardExistsInTeam_Should
    {
        [TestMethod]
        public void ThrowWhen_BoardExists()
        {
            var team = new FakeTeam("Team1");
            team.AddBoard(new FakeBoard("Board1"));
            var result = Assert.ThrowsException<ArgumentException>(() => Validator.BoardExistsInTeam("Board1", team));
            Assert.AreEqual("Board: 'Board1' already exists in team: 'Team1'", result.Message);
        }
    }
}
