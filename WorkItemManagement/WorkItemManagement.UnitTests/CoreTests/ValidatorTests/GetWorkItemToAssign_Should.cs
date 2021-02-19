using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class GetWorkItemToAssign_Should : Cleaner
    {
        [TestMethod]
        //public static IWorkItemsAssignee GetWorkItemToAssign(string id, IDatabase database)
        public void GetWorkItemToAssign_ReturnsWorkItem()
        {
            var fakeData = new FakeDatabase();
            var workItem = new Bug("1", "Bug 1 fixing", PriorityType.High, SeverityType.Critical, new List<string>(), "Bug 1 description.");
            fakeData.AddWorkItem(workItem);
            var workItemtoAssign = Validator.GetWorkItemToAssign("1", fakeData);
            Assert.IsInstanceOfType(workItemtoAssign, typeof(IWorkItemsAssignee));
            Assert.AreEqual(workItem, workItemtoAssign);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetWorkItemToAssign_ThrowWhen_WorkItemIsFeedback()
        {
            var fakeData = new FakeDatabase();
            var feedback = new Feedback("1", "Feedback Number 1", 5, "Feedback 1 description.");
            fakeData.AddWorkItem(feedback);
            Validator.GetWorkItemToAssign("1", fakeData);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetWorkItemToAssign_ThrowWhen_WorkItemNotExist()
        {
            var fakeData = new FakeDatabase();
            var workItem = new Bug("1", "Bug 1 fixing", PriorityType.High, SeverityType.Critical, new List<string>(), "Bug 1 description.");
            fakeData.AddWorkItem(workItem);
            Validator.GetWorkItemToAssign("2", fakeData);
        }

    }
}
