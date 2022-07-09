﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultancyManagement.Contract;
using ConsultancyManagement.Contract.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesignationAndDepartmentController : IDesignationAndDepartmentAppService
    {
        private readonly IDesignationAndDepartmentAppService _designationAndDepartmentAppService;

        public DesignationAndDepartmentController(
            IDesignationAndDepartmentAppService designationAndDepartmentAppService
            )
        {
            _designationAndDepartmentAppService = designationAndDepartmentAppService;
        }

        [HttpPost]
        [Route("createOrUpdateDerpartment")]
        public virtual Task CreateOrUpdateDepartment(DepartmentDto input)
        {
            return _designationAndDepartmentAppService.CreateOrUpdateDepartment(input);
        }

        [HttpPost]
        [Route("createOrUpdateDesignation")]
        public virtual Task CreateOrUpdateDesignation(DesignationDto input)
        {
            return _designationAndDepartmentAppService.CreateOrUpdateDesignation(input);
        }

        [HttpDelete]
        [Route("deleteDepartment/{id}")]
        public virtual Task DeleteDepartmentAsync(int id)
        {
            return _designationAndDepartmentAppService.DeleteDepartmentAsync(id);
        }

        [HttpDelete]
        [Route("deleteDesignation/{id}")]
        public virtual Task DeleteDesignationAsync(int id)
        {
            return _designationAndDepartmentAppService.DeleteDesignationAsync(id);
        }

        [HttpGet]
        [Route("getDepartment/{id}")]
        public virtual Task<DepartmentDto> GetDepartmentAsync(int id)
        {
            return _designationAndDepartmentAppService.GetDepartmentAsync(id);
        }


        [HttpGet]
        [Route("getDepartmentDropdown")]
        public virtual Task<List<DepartmentDto>> GetDepartmentDropdownAsync()
        {
            return _designationAndDepartmentAppService.GetDepartmentDropdownAsync();
        }


        [HttpGet]
        [Route("getDesignation/{id}")]
        public virtual Task<DesignationDto> GetDesignationAsync(int id)
        {
            return _designationAndDepartmentAppService.GetDesignationAsync(id);
        }

        [HttpGet]
        [Route("getDesignationDropdown")]
        public virtual Task<List<DesignationDto>> GetDesignationDropdownAsync()
        {
            return _designationAndDepartmentAppService.GetDesignationDropdownAsync();
        }
    }
}
