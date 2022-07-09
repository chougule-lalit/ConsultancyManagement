using ConsultancyManagement.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Contract
{
    public interface ICompanyMasterAppService
    {
        Task CreateOrUpdate(CompanyMasterDto input);
        Task<CompanyMasterDto> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<PagedResultDto<CompanyMasterDto>> FetchCompanyMasterListAsync(GetCompanyMasterInputDto input);
        Task<List<CompanyMasterDto>> GetCompanyMasterDropdownAsync();
    }
}
