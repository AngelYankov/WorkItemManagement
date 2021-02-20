using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;

namespace WorkItemManagement.UnitTests.Cleaner_Should
{
    [TestClass]
    public class CleanerDatabase
    {
        [TestCleanup]
        public void CleanUpDatabase()
        {
            Database.Instance.AllMembers.Clear();
            Database.Instance.AllTeams.Clear();
            Database.Instance.AllWorkItems.Clear();
        }
    }
}
