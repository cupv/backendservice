using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Place : Enity
    {
        public string Name { set; get; }
        public int Level { set; get; }
        public Guid LessionId { set; get; }
        public Lession Lession { set; get; }
        public string Latitude { set; get; }
        public string Longitude { set; get; }
    }
}
