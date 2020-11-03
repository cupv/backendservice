using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Enity
    {
        public Guid Id { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime CreatedDate { set; get; }
        public DateTime ModifiedDated { set; get; }

    }
}
