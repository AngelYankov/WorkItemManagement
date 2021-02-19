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
    public class MemberExists_Should : CleanerDatabase
    {
        [TestMethod]
        public void ThrowWhen_MemberExists()
        {
            var fakeMember = new FakeMember("Member1");
            Database.Instance.AddMemberToDB(fakeMember);
            var result = Assert.ThrowsException<ArgumentException>(() => Validator.MemberExists("Member1"));
                Assert.AreEqual("Member: 'Member1' already exists.", result.Message);
        }

    }
}
