using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Abstract;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.MemberTests
{
    [TestClass]
    public class RemoveWorkItems_Should : Cleaner
    {
        [TestMethod]
        public void RemoveWorkItemsShould_RemovedItem()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            var member = new Member("Bruce");
            member.AddWorkItems(feedback);
            member.RemoveWorkItems(feedback);
            Assert.AreEqual(member.WorkItems.Count, 0);
        }
        
    }
}
