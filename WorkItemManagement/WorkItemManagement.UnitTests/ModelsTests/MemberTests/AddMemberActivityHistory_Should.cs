using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.MemberTests
{
    [TestClass]
    public class AddMemberActivityHistory_Should
    {
        [TestMethod]
        public void ActivityHistory_Added()
        {
            var member = new Member("Bruce");
            var feedback = new Feedback("1020", "Feedbacktitle", 3, FeedbackStatusType.Done, "This is a description for feedback");
            member.AddWorkItems(feedback);

            Assert.AreEqual("Item: '1020' added.", string.Join("", member.ActivityHistory));
        }
    }
}
