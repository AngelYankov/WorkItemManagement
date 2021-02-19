using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.WorkItems;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class TeamExists_Should
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhen_TeamExists()
        {
            var fakeData = new FakeDatabase();
            fakeData.AddTeam(new Team("Team1"));

            Validator.TeamExists("Team1", fakeData);
            /*using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDatabase>();
            }*/
        }
        
    }
}
