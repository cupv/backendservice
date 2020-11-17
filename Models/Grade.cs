using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class Grade : Enity
    {
        public string Name { set; get; }
        public ICollection<User> Users { set; get; }
    }
}
