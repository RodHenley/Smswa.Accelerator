using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smswa.accelerator.data;
using smswa.accelerator.service.contract.Commands.Person;
using smswa.accelerator.service.Handlers.Person;

namespace smswa.accelerator.test.integration.service
{
    [TestClass]
    public class GetPersonHandlerTest
    {
        [TestMethod]
        public void GetTest()
        {
            var context = new AcceleratorContext();
            var handler = new GetPersonHandler(context);

            var requestParams = new[] {-1, 0, 1, int.MaxValue};

            foreach (var requestParam in requestParams)
            {
                var result = handler.Handle(new GetPersonRequest { Id = requestParam });
                Assert.IsNotNull(result);
                Assert.IsFalse(result.Result.Success);
            }

        }
    }
}
