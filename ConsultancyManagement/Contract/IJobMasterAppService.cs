using ConsultancyManagement.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Contract
{
    public interface IJobMasterAppService
    {
        Task CreateOrUpdate(JobMasterDto input);
        Task<JobMasterDto> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<PagedResultDto<JobMasterDto>> FetchJobMasterListAsync(GetJobMasterInputDto input);
    }
}
