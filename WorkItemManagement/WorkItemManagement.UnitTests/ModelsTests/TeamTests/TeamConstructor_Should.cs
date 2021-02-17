using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.TeamTests
{
    [TestClass]
    public class TeamConstructor_Should
    {
        [TestMethod]
        public void SetProperties()
        {
            var member = new Team("Team1");
            Assert.AreEqual("Team1", member.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullName()
        {
            var member = new Team(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_MinLengthName()
        {
            var member = new Team(new string('a', 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_MaxLengthName()
        {
            var member = new Team(new string('a', 11));
        }
        [TestMethod]
        public void Members_Initialized()
        {
            var member = new Team("Team1");
            Assert.AreEqual(member.Members.Count, 0);
        }

        [TestMethod]
        public void Boards_Initialized()
        {
            var member = new Team("Team1");
            Assert.AreEqual(member.Boards.Count, 0);
        }
    }
}
