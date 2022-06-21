using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiActor.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
