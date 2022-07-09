using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Contract.Dto
{
    public class CompanyMasterDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
    }

    public class GetCompanyMasterInputDto : PagedResultInput
    {

    }
}
