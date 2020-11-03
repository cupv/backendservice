using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Data.Infrastructure
{
    public class FactoryContext: IFactoryContext
    {
        private TestContext dataContext = new TestContext();
        public TestContext Init()
        {
            return dataContext;
        }
    }
}
