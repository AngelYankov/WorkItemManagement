using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void ThrowArgumentNullException_NullName()
        {
            var result = Assert.ThrowsException<ArgumentNullException>(() => new Team(null));
            Assert.AreEqual("Value cannot be null.", result.Message);
        }

        [TestMethod]
        public void ThrowArgumentException_MinLengthName()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => new Team(new string('a', 2)));
            Assert.AreEqual("Team name should be between 3 and 10 characters.", result.Message);
        }

        [TestMethod]
        public void ThrowArgumentException_MaxLengthName()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => new Team(new string('a', 11)));
            Assert.AreEqual("Team name should be between 3 and 10 characters.", result.Message);
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
