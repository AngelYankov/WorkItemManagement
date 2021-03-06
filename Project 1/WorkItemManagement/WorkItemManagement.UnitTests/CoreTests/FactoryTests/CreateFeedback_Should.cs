using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CoreTests.FactoryTests
{
    [TestClass]
    public class CreateFeedback_Should : CleanerID
    {
        [TestMethod]
        public void CreateFeedback_Should_CreateFeedbackSuccessfully()
        {
            var feedback = Factory.Instance.CreateFeedback("1", "ThisFeedbackTitle", 3, "This is a description for feedback");
            Assert.IsInstanceOfType(feedback, typeof(IFeedback));
        }
    }
}
