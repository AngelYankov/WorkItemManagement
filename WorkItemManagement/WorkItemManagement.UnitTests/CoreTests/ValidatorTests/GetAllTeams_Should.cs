using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class GetAllTeams_Should
    {
        [TestMethod]
        public void GetAllTeams_Should_ReturnAllTeams()
        {
            var fakeData = new FakeDatabase();
            var allTeams = Validator.GetAllTeams(fakeData);

            Assert.IsInstanceOfType(allTeams, typeof(IList<ITeam>));
        }
    }
}
