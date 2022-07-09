using System;
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
    public class CompanyMasterController : ICompanyMasterAppService
    {
        private readonly ICompanyMasterAppService _companyMasterAppService;

        public CompanyMasterController(ICompanyMasterAppService companyMasterAppService)
        {
            _companyMasterAppService = companyMasterAppService;
        }

        [HttpPost]
        [Route("createOrUpdate")]
        public virtual Task CreateOrUpdate(CompanyMasterDto input)
        {
            return _companyMasterAppService.CreateOrUpdate(input);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _companyMasterAppService.DeleteAsync(id);
        }

        [HttpPost]
        [Route("fetchCompanyMasterList")]
        public virtual Task<PagedResultDto<CompanyMasterDto>> FetchCompanyMasterListAsync(GetCompanyMasterInputDto input)
        {
            return _companyMasterAppService.FetchCompanyMasterListAsync(input);
        }

        [HttpGet]
        [Route("get/{id}")]
        public virtual Task<CompanyMasterDto> GetAsync(int id)
        {
            return _companyMasterAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("getCompanyMasterDropdown")]
        public virtual Task<List<CompanyMasterDto>> GetCompanyMasterDropdownAsync()
        {
            return _companyMasterAppService.GetCompanyMasterDropdownAsync();
        }
    }
}
