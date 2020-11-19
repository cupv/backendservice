using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Campaign : Enity
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Settings { set; get; }
        public int Status { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public Guid UserId { set; get; }
    }

    public class Setting
    {
        List<Site> Sites { get; set; }
    }

    public class Site {
        public string Location { get; set; }
        public Guid LessionId { get; set; }
        public Guid QuizId { get; set; }
    }
}
