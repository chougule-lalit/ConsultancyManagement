using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Entities
{
    public class UserMaster
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public RoleMaster Role { get; set; }
        
        public int RoleId { get; set; }

        public virtual Designation Designation { get; set; }

        public virtual int DesignationId { get; set; }

        public virtual Department Department { get; set; }

        public virtual int DepartmentId { get; set; }
    }
}
