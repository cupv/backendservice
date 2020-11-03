using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;

namespace Test.Data.Infrastructure
{
    public interface IFactoryContext
    {
        TestContext Init();
    }
}
