using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.TeamTests
{
    [TestClass]
    public class MemberConstructor_Should
    {
        [TestMethod]
        public void SetProperties()
        {
            var member = new Member("Bruce");
            Assert.AreEqual("Bruce", member.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullName()
        {
            new Member(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_MinLengthName()
        {
            new Member(new string('a', 4));
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_MaxLengthName()
        {
            new Member(new string('a', 16));
        }
    }
}
