using AutoMapper;
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
                       join d in _dbContext.Designations on u.DesignationId equals d.Id
                       join dp in _dbContext.Departments on u.DepartmentId equals dp.Id
                       select new UserMasterDto
                       {
                           Email = u.Email,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Id = u.Id,
                           Phone = u.Phone,
                           RoleId = r.Id,
                           RoleName = r.Name,
                           DepartmentId = u.DepartmentId,
                           DesignationId = u.DesignationId,
                           DepartmentName = dp.Name,
                           DesignationName = d.Name
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
            var user = await (from u in _dbContext.UserMasters
                               join r in _dbContext.RoleMasters on u.RoleId equals r.Id
                               join d in _dbContext.Departments on u.DepartmentId equals d.Id
                               join ds in _dbContext.Designations on u.DesignationId equals ds.Id
                               select new
                               {
                                   User = u,
                                   RoleName = r.Name,
                                   DepartmentName = d.Name,
                                   DesignationName = ds.Name
                               }).FirstOrDefaultAsync();

            if (user == null)
                return null;

            var returnData = _mapper.Map<UserMasterDto>(user.User);
            returnData.RoleName = user.RoleName;
            returnData.DepartmentName = user.DepartmentName;
            returnData.DesignationName = user.DesignationName;


            return returnData;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _dbContext.UserMasters.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _dbContext.UserMasters.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<LoginOutputDto> LoginAsync(LoginInputDto input)
        {
            var output = new LoginOutputDto();
            var user = await _dbContext.UserMasters.FirstOrDefaultAsync(x => x.Email == input.Email);
            if (user != null)
            {
                if (input.Password == user.Password)
                {
                    output.IsSuccess = true;
                    output.Role = (RoleEnum)user.RoleId;
                    output.Id = user.Id;
                }
                else
                    return output;
            }

            return output;
        }

    }
}
