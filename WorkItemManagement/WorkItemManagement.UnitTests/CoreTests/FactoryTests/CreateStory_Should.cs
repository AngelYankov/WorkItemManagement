using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CoreTests.FactoryTests
{
    [TestClass]
    public class CreateStory_Should : Cleaner
    {
        [TestMethod]
        public void CreateStoryShould_CreateSuccessfully()
        {
            var story = Factory.Instance.CreateStory("1", "This is the story 12 title", "high", "large", "this is the story 12 description");
            Assert.IsInstanceOfType(story, typeof(IStory));
        }

        [TestMethod]
        public void CreateStoryShould_ThrowWhen_WrongPriority()
        {
           var result = Assert.ThrowsException<ArgumentException>(()
               => Factory.Instance.CreateStory("1", "This is the story 12 title", "wrong", "large", "this is the story 12 description"));
            Assert.AreEqual("Story priority 'wrong' is not valid", result.Message);
        }

        [TestMethod]
        public void CreateStoryShould_ThrowWhen_WrongSize()
        {
            var result = Assert.ThrowsException<ArgumentException>(()
               => Factory.Instance.CreateStory("1", "This is the story 12 title", "high", "wrong", "this is the story 12 description"));
            Assert.AreEqual("Story size 'wrong' is not valid", result.Message);
        }
    }
}
