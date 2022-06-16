﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ConsultancyManagement.Contract;
using ConsultancyManagement.Contract.Dto;
using ConsultancyManagement.Data;
using ConsultancyManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultancyManagement.Application
{
    public class UserMasterAppService : IUserMasterAppService
    {
        private readonly ConsultancyManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserMasterAppService(
            ConsultancyManagementDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateOrUpdateUser(UserMasterCreateUpdateDto input)
        {
            if (input.Id.HasValue)
            {
                var user = await _dbContext.UserMasters.FirstOrDefaultAsync(x => x.Id == input.Id.Value);
                if (user != null)
                {
                    _mapper.Map(input, user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            else
            {
                var userToCreate = _mapper.Map<UserMaster>(input);
                await _dbContext.AddAsync(userToCreate);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PagedResultDto<UserMasterDto>> FetchUserListAsync(GetUserInput input)
        {
            var data = from u in _dbContext.UserMasters
                       join r in _dbContext.RoleMasters on u.RoleId equals r.Id
                       select new UserMasterDto
                       {
                           Email = u.Email,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Id = u.Id,
                           Phone = u.Phone,
                           RoleId = r.Id,
                           RoleName = r.Name
                       };

            if (!string.IsNullOrEmpty(input.Search))
                data = data.Where(x => x.FirstName.ToLower().Contains(input.Search.ToLower()) ||
                            x.LastName.ToLower().Contains(input.Search.ToLower()));

            var count = data.Count();

            var userList = await data.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            return new PagedResultDto<UserMasterDto>
            {
                Items = userList,
                TotalCount = count
            };
        }

        public async Task<UserMasterDto> GetUserAsync(int id)
        {
            var user = await _dbContext.UserMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return null;

            return _mapper.Map<UserMasterDto>(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _dbContext.UserMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _dbContext.UserMasters.Remove(user);
            }
        }

    }
}
