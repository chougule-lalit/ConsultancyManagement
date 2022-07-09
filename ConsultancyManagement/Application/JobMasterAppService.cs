using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConsultancyManagement.Contract;
using ConsultancyManagement.Contract.Dto;
using ConsultancyManagement.Data;
using ConsultancyManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsultancyManagement.Application
{
    public class JobMasterAppService: IJobMasterAppService
    {
        private readonly ConsultancyManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        public JobMasterAppService(
            ConsultancyManagementDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateOrUpdate(JobMasterDto input)
        {
            if (input.Id.HasValue)
            {
                var user = await _dbContext.JobMasters.FirstOrDefaultAsync(x => x.Id == input.Id.Value);
                if (user != null)
                {
                    _mapper.Map(input, user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            else
            {
                var userToCreate = _mapper.Map<JobMaster>(input);
                await _dbContext.AddAsync(userToCreate);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<JobMasterDto> GetAsync(int id)
        {
            var data = await _dbContext.JobMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return null;

            return _mapper.Map<JobMasterDto>(data);
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dbContext.JobMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (data != null)
            {
                _dbContext.JobMasters.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PagedResultDto<JobMasterDto>> FetchJobMasterListAsync(GetJobMasterInputDto input)
        {
            var data = await _dbContext.JobMasters.ToListAsync();

            var count = data.Count;

            var returnData = data.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            return new PagedResultDto<JobMasterDto>
            {
                Items = _mapper.Map<List<JobMasterDto>>(returnData),
                TotalCount = count
            };
        }
    }
}
