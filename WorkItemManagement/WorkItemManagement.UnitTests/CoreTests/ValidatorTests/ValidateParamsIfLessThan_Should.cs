using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Core;
using WorkItemManagement.UnitTests.Cleaner_Should;

namespace WorkItemManagement.UnitTests.CoreTests.ValidatorTests
{
    [TestClass]
    public class ValidateParamsIfLessThan_Should : TestBaseClass
    {
        [TestMethod]
        
        public void ThrowWhen_DiffCountParams()
        {
            var validator = new Validator(database);
            var result = Assert.ThrowsException<ArgumentException>(()=>validator.ValidateParameters(new List<string>(), 1));
            Assert.AreEqual("Parameters count is not valid", result.Message);
        }
    }
}
