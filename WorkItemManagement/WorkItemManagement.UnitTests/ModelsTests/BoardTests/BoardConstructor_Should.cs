using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullName()
        {
            var board = new Board(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Board name should be between 5 and 10 characters.")]
        public void ThrowArgumentException_MinLengthName()
        {
            var board = new Board(new string('a',4));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Board name should be between 5 and 10 characters.")]
        public void ThrowArgumentException_MaxLengthName()
        {
            var board = new Board(new string('a', 11));

        }
    }
}
