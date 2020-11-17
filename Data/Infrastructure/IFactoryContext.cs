using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;

namespace API.Data.Infrastructure
{
    public interface IFactoryContext
    {
        ApplicationDbContext Init();
    }
}
