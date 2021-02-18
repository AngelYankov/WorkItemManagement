using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
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
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStoryShould_ThrowWhen_WrongPriority()
        {
           Factory.Instance.CreateStory("1", "This is the story 12 title", "wrong", "large", "this is the story 12 description");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateStoryShould_ThrowWhen_WrongSize()
        {
            Factory.Instance.CreateStory("1", "This is the story 12 title", "high", "wrong", "this is the story 12 description");
        }
    }
}
