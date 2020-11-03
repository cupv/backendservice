using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Lession : Enity
    {
        public string Name { set; get; }
        public Guid CourseId { set; get; }
        public Course Course { set; get; }
    }
}
