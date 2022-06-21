using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiActor.Entity
{
    public class Actor:BaseEntity
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
    }
}
