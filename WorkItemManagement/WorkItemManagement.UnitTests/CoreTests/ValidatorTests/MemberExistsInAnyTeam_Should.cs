using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class MemberExistsInAnyTeam_Should
    {
        [TestMethod]
        public void ThrowWhen_MemberDoesNotExistInTeam()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => Validator.MemberExistsInAnyTeam("Member1"));
            Assert.AreEqual("Member: 'Member1' is not in any team.", result.Message);
        }
    }
}
