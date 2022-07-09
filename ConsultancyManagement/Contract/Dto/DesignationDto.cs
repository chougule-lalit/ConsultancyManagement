﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Contract.Dto
{
    public class DesignationDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }
    }

    public class DepartmentDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }
    }

    public class GetDesignationInputDto : PagedResultInput
    {

    }

    public class GetDepartmentInputDto : PagedResultInput
    {

    }
}
