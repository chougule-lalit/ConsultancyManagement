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
    public class JobMasterController : IJobMasterAppService
    {
        private readonly IJobMasterAppService _jobMasterAppService;

        public JobMasterController(IJobMasterAppService jobMasterAppService)
        {
            _jobMasterAppService = jobMasterAppService;
        }

        [HttpPost]
        [Route("createOrUpdate")]
        public virtual Task CreateOrUpdate(JobMasterDto input)
        {
            return _jobMasterAppService.CreateOrUpdate(input);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _jobMasterAppService.DeleteAsync(id);
        }

        [HttpPost]
        [Route("fetchJobMasterList")]
        public virtual Task<PagedResultDto<JobMasterDto>> FetchJobMasterListAsync(GetJobMasterInputDto input)
        {
            return _jobMasterAppService.FetchJobMasterListAsync(input);
        }

        [HttpGet]
        [Route("get/{id}")]
        public virtual Task<JobMasterDto> GetAsync(int id)
        {
            return _jobMasterAppService.GetAsync(id);
        }
    }
}
