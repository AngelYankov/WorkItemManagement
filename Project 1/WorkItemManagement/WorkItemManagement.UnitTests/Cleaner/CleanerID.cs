using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Abstract;

namespace WorkItemManagement.UnitTests.Cleaner_Should
{
    [TestClass]
    public class CleanerID
    {
        [TestCleanup]
        public void CleanUp()
        {
            WorkItem.allIds.Clear();
        }
    }
}
