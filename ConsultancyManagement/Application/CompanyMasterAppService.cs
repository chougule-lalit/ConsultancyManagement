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
    public class CompanyMasterAppService : ICompanyMasterAppService
    {
        private readonly ConsultancyManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompanyMasterAppService(
            ConsultancyManagementDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateOrUpdate(CompanyMasterDto input)
        {
            if (input.Id.HasValue)
            {
                var user = await _dbContext.CompanyMasters.FirstOrDefaultAsync(x => x.Id == input.Id.Value);
                if (user != null)
                {
                    _mapper.Map(input, user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            else
            {
                var userToCreate = _mapper.Map<CompanyMaster>(input);
                await _dbContext.AddAsync(userToCreate);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<CompanyMasterDto> GetAsync(int id)
        {
            var data = await _dbContext.CompanyMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
                return null;

            return _mapper.Map<CompanyMasterDto>(data);
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dbContext.CompanyMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (data != null)
            {
                _dbContext.CompanyMasters.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PagedResultDto<CompanyMasterDto>> FetchCompanyMasterListAsync(GetCompanyMasterInputDto input)
        {
            var data = await _dbContext.CompanyMasters.ToListAsync();

            var count = data.Count;

            var returnData = data.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            return new PagedResultDto<CompanyMasterDto>
            {
                Items = _mapper.Map<List<CompanyMasterDto>>(returnData),
                TotalCount = count
            };
        }

        public async Task<List<CompanyMasterDto>> GetCompanyMasterDropdownAsync()
        {
            var data = await _dbContext.CompanyMasters.ToListAsync();

            return _mapper.Map<List<CompanyMasterDto>>(data);
        }
    }
}
