using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Infrastructure
{
    public class FactoryContext: IFactoryContext
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        public ApplicationDbContext Init()
        {
            return dataContext;
        }
    }
}
