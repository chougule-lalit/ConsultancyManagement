using AutoMapper;
using ConsultancyManagement.Contract;
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
    public class SkillMasterAppService : ISkillMasterAppService
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

            var dataQuerable = from u in _dbContext.UserMasters
                               join s in _dbContext.SkillMasters on u.Id equals s.UserMasterId
                               select new SkillMasterDto
                               {
                                   UserName = $"{u.FirstName} {u.LastName}",
                                   UserMasterId = s.UserMasterId,
                                   ExperienceInMonths = s.ExperienceInMonths,
                                   Id = s.Id,
                                   Name = s.Name
                               };

            if (input.UserMasterId.HasValue)
                dataQuerable = dataQuerable.Where(x => x.UserMasterId == input.UserMasterId.Value);

            var data = await dataQuerable.ToListAsync();

            var count = data.Count;

            var returnData = data.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            return new PagedResultDto<SkillMasterDto>
            {
                Items = _mapper.Map<List<SkillMasterDto>>(returnData),
                TotalCount = count
            };
        }

        public async Task<List<SkillMasterDropDownDto>> GetSkillDropdownAsync()
        {
            return await _dbContext.SkillMasters.Select(x => new SkillMasterDropDownDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
