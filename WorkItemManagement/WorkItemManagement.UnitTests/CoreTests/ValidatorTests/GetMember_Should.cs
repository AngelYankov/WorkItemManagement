using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    class GetMember_Should
    {
        [TestMethod]
        public void GetMember_Should_ReturnMember()
        {
            var fakeData = new FakeDatabase();
            var membertoGet = new Member("Member1");
            fakeData.AddMember(membertoGet);
            var member = Validator.GetMember("Member1", fakeData);

            Assert.IsInstanceOfType(member, typeof(IMember));
            Assert.AreEqual("Member1", member.Name);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhen_MemberDoesNotExist()
        {
            var fakeData = new FakeDatabase();
            Validator.GetMember("Member1", fakeData);
        }
    }
}
