using System;
using System.Collections.Generic;

namespace Test.Models
{
    public class Class : Enity
    {
        public string Name { set; get; }
        public Guid CourseId { set; get; }
        public Course Course { set; get; }

        public virtual ICollection<ClassUser> ClassUser { get; set; }
    }
}
