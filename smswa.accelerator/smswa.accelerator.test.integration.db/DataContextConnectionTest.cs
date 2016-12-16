using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smswa.accelerator.data;

namespace smswa.accelerator.test.integration.db
{
    [TestClass]
    public class DataContextConnectionTest
    {
        [TestMethod]
        public void Connect()
        {
            var context = new AcceleratorContext();
            Assert.IsNotNull(context);
            Assert.IsTrue(context.Persons.Count(x=>x.Id == 0) == 0);
        }
    }
}
