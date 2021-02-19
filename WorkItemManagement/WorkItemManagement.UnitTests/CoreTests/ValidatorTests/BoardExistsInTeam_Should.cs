using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class BoardExistsInTeam_Should
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhen_BoardExists()
        {
            //public static void BoardExistsInTeam(string name,ITeam team) // emo
            var team = new Team("Team1");
            team.AddBoard(new Board("Board1"));
            Validator.BoardExistsInTeam("Board1", team);
        }
    }
}
