using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Entities
{
    public class Designation : BaseEntity
    {
        public virtual string Name { get; set; }
    }
}
