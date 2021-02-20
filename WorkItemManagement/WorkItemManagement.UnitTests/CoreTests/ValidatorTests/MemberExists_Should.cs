using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Core;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class MemberExists_Should : TestBaseClass
    {
        [TestMethod]
        public void ThrowWhen_MemberExists()
        {
            var validator = new Validator(database);
            var result = Assert.ThrowsException<ArgumentException>(() => validator.MemberExists("Member1"));
                Assert.AreEqual("Member: 'Member1' already exists.", result.Message);
        }

    }
}
