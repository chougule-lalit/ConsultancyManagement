using ConsultancyManagement.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Contract
{
    public interface ISkillMasterAppService
    {
        Task CreateOrUpdate(SkillMasterDto input);
        Task<SkillMasterDto> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<PagedResultDto<SkillMasterDto>> FetchSkillMasterListAsync(GetSkillMasterInputDto input);
    }
}
