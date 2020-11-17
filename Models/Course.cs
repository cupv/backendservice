using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Course : Enity
    {
        public string Name { set; get; }
        public string Code { set; get; }
        public List<Class> Class { set; get; }
    }
}
