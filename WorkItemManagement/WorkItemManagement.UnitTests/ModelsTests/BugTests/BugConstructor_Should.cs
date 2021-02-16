using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Enums;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.ModelsTests.BugTests
{
    [TestClass]
    public class BugConstructor_Should
    {
        [TestMethod]
        public void SetProperties()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1025", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            Assert.AreEqual("1025", bug.Id);
            Assert.AreEqual("TheFirstBug", bug.Title);
            Assert.AreEqual(PriorityType.High, bug.Priority);
            Assert.AreEqual(SeverityType.Critical, bug.Severity);
            Assert.AreEqual(BugStatus.Active, bug.Status);
            Assert.AreEqual("This is a description for a bug", bug.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullTitle()
        {
            var steps = new List<string>() { "first-second-third" };
            var bug = new Bug("1026", null, PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_IdExists()
        {
            var steps = new List<string>() { "first-second-third" };
            new Bug("1027", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
            new Bug("1027", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullId()
        {
            var steps = new List<string>() { "first-second-third" };
            new Bug(null, "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Max_Id()
        {
            var steps = new List<string>() { "first-second-third" };
            new Bug(new string('a', 11), "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullException_NullDescription()
        {
            var steps = new List<string>() { "first-second-third" };
            new Bug("1028", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MinLength_Title()
        {
            var steps = new List<string>() { "first-second-third" };
            new Bug("1029", new string('a', 9), PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxLength_Title()
        {
            var steps = new List<string>() { "first-second-third" };
            new Bug("1030", new string('a', 51), PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, "This is a description for a bug");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MinLength_Description()
        {
            var steps = new List<string>() { "first-second-third" };
            new Bug("1031", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, new string('a', 9));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MaxLength_Description()
        {
            var steps = new List<string>() { "first-second-third" };
            new Bug("1032", "TheFirstBug", PriorityType.High, SeverityType.Critical, BugStatus.Active, steps, new string('a', 501));
        }
    }
}
