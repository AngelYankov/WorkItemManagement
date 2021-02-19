using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

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
