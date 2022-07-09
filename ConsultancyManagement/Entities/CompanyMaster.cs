using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Entities
{
    public class CompanyMaster : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual bool Active { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
    }
}
