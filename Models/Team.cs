using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Team : Enity
    {
        public string Name { set; get; }
        public string Slogan { set; get; }
        public Guid ClassId { set; get; }
        public Class Class { set; get; }
    }
}
