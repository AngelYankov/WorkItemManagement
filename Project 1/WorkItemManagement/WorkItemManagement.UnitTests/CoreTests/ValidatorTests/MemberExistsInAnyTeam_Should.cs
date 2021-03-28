using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Core;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class MemberExistsInAnyTeam_Should : TestBaseClass
    {
        [TestMethod]
        public void ThrowWhen_MemberDoesNotExistInTeam()
        {
            var validator = new Validator(database);
            var result = Assert.ThrowsException<ArgumentException>(() => validator.MemberExistsInAnyTeam("Member5"));
            Assert.AreEqual("Member: 'Member5' is not in any team.", result.Message);
        }
    }
}
