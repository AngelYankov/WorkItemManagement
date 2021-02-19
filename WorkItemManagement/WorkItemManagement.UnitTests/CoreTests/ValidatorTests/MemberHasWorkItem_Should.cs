using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class MemberHasWorkItem_Should
    {
        [TestMethod]
        public void ThrowWhen_MemberDoesNotHaveWorkItem()
        {
            var member = new FakeMember("Member1");
            var workItem = new FakeFeedback();
            workItem.Id = "1";
            var result = Assert.ThrowsException<ArgumentException>(() => Validator.MemberHasWorkItem(workItem, member));
            Assert.AreEqual("Member: 'Member1' does not have access to work item: '1'.", result.Message);
        }
    }
}
