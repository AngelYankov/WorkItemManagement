using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CoreTests.FactoryTests
{
    [TestClass]
    public class CreateBug_Should : CleanerID
    {
        [TestMethod]
        public void CreateBug_Should_CreateBugSuccessfully()
        {
            var bug = Factory.Instance.CreateBug("1", "TheFirstBug", "high", "critical", new List<string>(), "This is a description for a bug");
            Assert.IsInstanceOfType(bug, typeof(IBug));
        }

        [TestMethod]
        public void CreateBug_Should_ThrowWrongPriority()
        {
            var result = Assert.ThrowsException<ArgumentException>(() 
                => Factory.Instance.CreateBug("1", "TheFirstBug", "wrong", "critical", new List<string>(), "This is a description for a bug"));
            Assert.AreEqual("Bug priority 'wrong' is not valid", result.Message);
        }
        
        [TestMethod]
        public void CreateBug_Should_ThrowWrongSeverity()
        {
            var result = Assert.ThrowsException<ArgumentException>(()
                => Factory.Instance.CreateBug("1", "TheFirstBug", "high", "wrong", new List<string>(), "This is a description for a bug"));
            Assert.AreEqual("Bug severity 'wrong' is not valid", result.Message);
        }
    }
}
