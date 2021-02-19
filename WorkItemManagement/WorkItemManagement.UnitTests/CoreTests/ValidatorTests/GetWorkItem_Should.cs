using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class GetWorkItem_Should : Cleaner
    {
        [TestMethod]
        public void GetWorkItem_Should_ReturnWorkItem()
        {
            var fakeData = new FakeDatabase();
            var feedback = new Feedback("1", "FeedbackNumber1", 3, "This is a description");
            fakeData.AddWorkItem(feedback);
            var workItem = Validator.GetWorkItem("1", fakeData);

            Assert.IsInstanceOfType(workItem, typeof(IWorkItem));
            Assert.AreEqual("1", workItem.Id);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhen_WorkItemDoesNotExist()
        {
            var fakeData = new FakeDatabase();
            Validator.GetWorkItem("1", fakeData);
        }
    }
}
