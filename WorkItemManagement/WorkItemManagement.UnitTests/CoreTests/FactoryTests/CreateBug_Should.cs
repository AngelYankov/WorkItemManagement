using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CoreTests.FactoryTests
{
    [TestClass]
    public class CreateBug_Should : Cleaner
    {
        [TestMethod]
        public void CreateBug_Should_CreateBugSuccessfully()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = Factory.Instance.CreateBug("1", "TheFirstBug", "high", "critical", steps, "This is a description for a bug");
            Assert.IsInstanceOfType(bug, typeof(IBug));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBug_Should_ThrowWrongPriority()
        {
            var steps = new List<string>() { "first-second-third" };
            Factory.Instance.CreateBug("1", "TheFirstBug", "wrong", "critical", steps, "This is a description for a bug");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBug_Should_ThrowWrongSeverity()
        {
            var steps = new List<string>() { "first-second-third" };
            Factory.Instance.CreateBug("1", "TheFirstBug", "high", "wrong", steps, "This is a description for a bug");
        }
    }
}
