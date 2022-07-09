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
    public class SkillMasterController
    {
        private readonly ISkillMasterAppService _skillMasterAppService;

        public SkillMasterController(ISkillMasterAppService skillMasterAppService)
        {
            _skillMasterAppService = skillMasterAppService;
        }

        [HttpPost]
        [Route("createOrUpdate")]
        public virtual Task CreateOrUpdate(SkillMasterDto input)
        {
            return _skillMasterAppService.CreateOrUpdate(input);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _skillMasterAppService.DeleteAsync(id);
        }

        [HttpPost]
        [Route("fetchSkillMasterList")]
        public virtual Task<PagedResultDto<SkillMasterDto>> FetchSkillMasterListAsync(GetSkillMasterInputDto input)
        {
            return _skillMasterAppService.FetchSkillMasterListAsync(input);
        }

        [HttpGet]
        [Route("get/{id}")]
        public virtual Task<SkillMasterDto> GetAsync(int id)
        {
            return _skillMasterAppService.GetAsync(id);
        }
    }
}
