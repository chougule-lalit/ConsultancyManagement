using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Contract.Dto
{
    public class JobMasterDto
    {
        public int? Id { get; set; }
        public int CompanyMasterId { get; set; }
        public string CompanyName { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int VacancyAvailable { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
    }

    public class GetJobMasterInputDto : PagedResultInput
    {
        public int? CompanyMasterId { get; set; }
        public int? DesignationId { get; set; }
    }
}
