using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.BoardTests
{
    [TestClass]
    public class BoardConstructor_Should
    {
        [TestMethod]
        public void SetProperties()
        {
            var board = new Board("Board1");
            Assert.AreEqual("Board1", board.Name);
        }

        [TestMethod]
        public void ThrowArgumentNullException_NullName()
        {
            var result = Assert.ThrowsException<ArgumentNullException>(() => new Board(null));
            Assert.AreEqual("Value cannot be null.", result.Message);
        }

        [TestMethod]
        public void ThrowArgumentException_MinLengthName()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => new Board(new string('a',4)));
            Assert.AreEqual("Board name should be between 5 and 10 characters.", result.Message);
        }

        [TestMethod]
        public void ThrowArgumentException_MaxLengthName()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => new Board(new string('a', 11)));
            Assert.AreEqual("Board name should be between 5 and 10 characters.", result.Message);
        }

        [TestMethod]
        public void ActivityHistory_Initialized()
        {
            var board = new Board("Board1");
            Assert.AreEqual(0, board.ActivityHistory.Count);
        }

        [TestMethod]
        public void WorkItems_Initialized()
        {
            var board = new Board("Board1");
            Assert.AreEqual(0, board.WorkItems.Count);
        }
    }
}
