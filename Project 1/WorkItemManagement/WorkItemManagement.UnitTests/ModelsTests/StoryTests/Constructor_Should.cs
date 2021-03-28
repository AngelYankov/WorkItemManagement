using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.StoryTests
{
    [TestClass]
    public class Constructor_Should : CleanerID
    {
        [TestMethod] 
        public void SetProperties()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, SizeType.Large, "this is the story 12 description");
            Assert.AreEqual(PriorityType.High, story.Priority);
            Assert.AreEqual(StoryStatusType.NotDone, story.StoryStatus);
            Assert.AreEqual(SizeType.Large, story.Size);
        }
    }
}
