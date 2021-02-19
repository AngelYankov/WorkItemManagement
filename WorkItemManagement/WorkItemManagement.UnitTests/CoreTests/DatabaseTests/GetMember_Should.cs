using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class GetMember_Should : CleanerDatabase
    {
        [TestMethod]
        public void Returns_Member()
        {
            var db = Database.Instance;
            var member = new FakeMember("Member2");
            db.AddMemberToDB(member);
            var expected = db.GetMember("Member2");
            Assert.AreEqual(member, expected);
        }

        [TestMethod]
        public void ThrowsWhen_MemberDoesNotExist()
        {
            var db = Database.Instance;
            var result = Assert.ThrowsException<ArgumentException>(() => db.GetMember("Member1"));
            Assert.AreEqual("Member: 'Member1' does not exist.", result.Message);
        }
    }
}
