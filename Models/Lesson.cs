using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Lesson : Enity
    {
        public string Name { set; get; }
        public Guid CourseId { set; get; }
        public string Content { get; set; }
        public Course Course { set; get; }
        public string Url { set; get; }
        public Guid? QuizId { set; get; }
        public Quiz Quiz { set; get; }
    }

    public class Content
    {
        public List<Unit> Units { get; set; }
    }

    public class Unit
    {
        public string Label { get; set; }

        public string Url { get; set; }
    }
}
