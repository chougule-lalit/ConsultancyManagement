using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Contract.Dto
{
    public class SkillMasterDto
    {
        public int? Id { get; set; }
        public int UserMasterId { get; set; }
        public string Name { get; set; }
        public int ExperienceInMonths { get; set; }
    }

    public class GetSkillMasterInputDto : PagedResultInput
    {

    }
}
