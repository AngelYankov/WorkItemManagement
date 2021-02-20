using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.StoryTests
{
    [TestClass]
    public class ChangeStatus_Should : CleanerID
    {
        [TestMethod]
        public void StatusChanged_NewStatus()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            story.ChangeStatus(StoryStatusType.Done);
            Assert.AreEqual(StoryStatusType.Done, story.StoryStatus);
        }

        [TestMethod]
        public void StatusNotChanged_SameStatus()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            var result = Assert.ThrowsException<ArgumentException>(() => story.ChangeStatus(StoryStatusType.NotDone));
            Assert.AreEqual("Status already at 'NotDone'.", result.Message);
        }
    }
}
