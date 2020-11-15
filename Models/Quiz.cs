using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Quiz : Enity
    {
        public string Name { set; get; }
        public string Description { set; get; }
    }

    public class Question
    {
        public string Name { set; get; }
        public string Type { set; get; }
        public bool Required { set; get; }
        public List<Answer> Answers { set; get; }
    }
    public class Answer
    {
        public string Label { set; get; }
        public string Value { set; get; }
        public bool Choice { set; get; }
    }
}
