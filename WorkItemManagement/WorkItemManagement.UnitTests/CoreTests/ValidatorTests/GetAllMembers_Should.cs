using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class GetAllMembers_Should
    {
        [TestMethod]
        public void GetAllMembers_Should_ReturnAllMembers()
        {
            var fakeData = new FakeDatabase();
            var members = Validator.GetAllMembers(fakeData);

            Assert.IsInstanceOfType(members, typeof(IList<IMember>));
        }
    }
}
