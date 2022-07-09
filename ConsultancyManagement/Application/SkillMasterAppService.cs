using AutoMapper;
using ConsultancyManagement.Contract.Dto;
using ConsultancyManagement.Data;
using ConsultancyManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Application
{
    public class SkillMasterAppService
    {
        private readonly ConsultancyManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public SkillMasterAppService(
            ConsultancyManagementDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateOrUpdate(SkillMasterDto input)
        {
            if (input.Id.HasValue)
            {
                var user = await _dbContext.SkillMasters.FirstOrDefaultAsync(x => x.Id == input.Id.Value);
                if (user != null)
                {
                    _mapper.Map(input, user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            else
            {
                var userToCreate = _mapper.Map<SkillMaster>(input);
                await _dbContext.AddAsync(userToCreate);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<SkillMasterDto> GetAsync(int id)
        {
            var data = await _dbContext.SkillMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return null;

            return _mapper.Map<SkillMasterDto>(data);
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dbContext.SkillMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (data != null)
            {
                _dbContext.SkillMasters.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PagedResultDto<SkillMasterDto>> FetchSkillMasterListAsync(GetSkillMasterInputDto input)
        {
            var data = await _dbContext.SkillMasters.ToListAsync();

            var count = data.Count;

            var returnData = data.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            return new PagedResultDto<SkillMasterDto>
            {
                Items = _mapper.Map<List<SkillMasterDto>>(returnData),
                TotalCount = count
            };
        }
    }
}
