using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Entities
{
    public class SkillMaster : BaseEntity
    {
        public UserMaster UserMaster { get; set; }
        public int UserMasterId { get; set; }
        public string Name { get; set; }
        public int ExperienceInMonths { get; set; }
    }
}
