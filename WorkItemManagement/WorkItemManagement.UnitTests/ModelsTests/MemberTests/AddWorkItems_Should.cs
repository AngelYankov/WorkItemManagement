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
    public class AddWorkItems_Should : Cleaner
    {
        [TestMethod]
        public void AddWorkItems_Should_AddSuccessfully()
        {
            var feedback = new Feedback("1", "TheFirstFeedback", 3, "This is a feedback created");
            var member = new Member("Bruce");
            member.AddWorkItems(feedback);
            Assert.IsTrue(member.WorkItems.Contains(feedback));
        }
        
    }
}
