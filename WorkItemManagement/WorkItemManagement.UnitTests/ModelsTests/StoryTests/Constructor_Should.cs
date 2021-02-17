using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Abstract;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.ModelsTests.StoryTests
{
    [TestClass]
    public class Constructor_Should : Cleaner
    {
        [TestMethod] 
        public void SetProperties()
        {
            var story = new Story("1", "This is the story 12 title", PriorityType.High, StoryStatusType.Done, SizeType.Large, "this is the story 12 description");
            Assert.AreEqual(PriorityType.High, story.Priority);
            Assert.AreEqual(StoryStatusType.Done, story.StoryStatus);
            Assert.AreEqual(SizeType.Large, story.Size);
        }
        
    }
}
