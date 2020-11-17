using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Role : Enity
    {
        public string Name { set; get; }
        public string Action { set; get; }
    }
}
