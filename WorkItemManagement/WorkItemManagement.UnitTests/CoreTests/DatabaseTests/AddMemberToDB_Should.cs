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
    public class AddMemberToDB_Should : CleanerDatabase
    {
        [TestMethod]
        public void Should_AddMember()
        {
            var db = Database.Instance;
            var member = new FakeMember();
            db.AddMemberToDB(member);

            Assert.IsTrue(db.AllMembers.Contains(member));
        }
    }
}
