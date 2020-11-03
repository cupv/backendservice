using System;

namespace Test.Models
{
    public class Class : Enity
    {
        public string Name { set; get; }
        public Guid CourseId { set; get; }
        public Course Course { set; get; }
    }
}
