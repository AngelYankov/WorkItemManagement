using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.MemberTests
{
    [TestClass]
    public class AddWorkItems_Should : Cleaner
    {
        [TestMethod]
        public void AddWorkItems_Should_AddSuccessfully()
        {
            var feedback = new FakeFeedback();
            var member = new Member("Bruce");
            member.AddWorkItems(feedback);
            Assert.IsTrue(member.WorkItems.Contains(feedback));
        }
    }
}
