using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.CoreTests.DatabaseTests
{
    [TestClass]
    public class GetAllMembers_Should
    {
        [TestMethod]
        public void ReturnsAllMembers()
        {
            var db = Database.Instance;
            var members = db.GetAllMembers();
            Assert.IsInstanceOfType(members, typeof(IList<IMember>));
        }
    }
}
