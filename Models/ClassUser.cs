using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ClassUser
    {
        public Guid UserId { set; get; }
        public Guid ClassId { set; get; }
        public Class Class { set; get; }
        public User User { set; get; }
    }
}
