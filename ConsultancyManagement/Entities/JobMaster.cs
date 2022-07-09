using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Entities
{
    public class JobMaster : BaseEntity
    {
        public CompanyMaster CompanyMaster { get; set; }
        public int CompanyMasterId { get; set; }
        public Designation Designation { get; set; }
        public int DesignationId { get; set; }
        public int VacancyAvailable { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
    }
}
