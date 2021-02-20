using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;
using WorkItemManagement.UnitTests.FakeClasses;

namespace WorkItemManagement.UnitTests.ModelsTests.MemberTests
{
    [TestClass]
    public class RemoveWorkItems_Should : CleanerID
    {
        [TestMethod]
        public void RemoveWorkItemsShould_RemovedItem()
        {
            var feedback = new FakeFeedback();
            var member = new Member("Bruce");
            member.AddWorkItems(feedback);
            member.RemoveWorkItems(feedback);
            Assert.AreEqual(member.WorkItems.Count, 0);
        }
    }
}
