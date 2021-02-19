using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class MemberExistsInAnyTeam_Should
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhen_MemberDoesNotExistInTeam()
        {
            var fakeData = new FakeDatabase();
            Validator.MemberExistsInAnyTeam("Member1", fakeData);
        }
    }
}
