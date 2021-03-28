using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.TeamTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void SetProperties()
        {
            var member = new Member("Bruce");
            Assert.AreEqual("Bruce", member.Name);
        }

        [TestMethod]
        public void ThrowArgumentNullException_NullName()
        {
            var result = Assert.ThrowsException<ArgumentNullException>(() => new Member(null));
            Assert.AreEqual("Value cannot be null.", result.Message);
        }

        [TestMethod]
        public void ThrowArgumentException_MinLengthName()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => new Member(new string('a', 4)));
            Assert.AreEqual("Member name should be between 5 and 15 characters.", result.Message);
        }

        [TestMethod]
        public void ThrowArgumentException_MaxLengthName()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => new Member(new string('a', 16)));
            Assert.AreEqual("Member name should be between 5 and 15 characters.", result.Message);
        }

        [TestMethod]
        public void ActivityHistory_Initialized()
        {
            var member = new Member("Bruce");
            Assert.AreEqual(0, member.ActivityHistory.Count);
        }

        [TestMethod]
        public void WorkItems_Initialized()
        {
            var member = new Member("Bruce");
            Assert.AreEqual(0, member.WorkItems.Count);
        }
    }
}
