﻿using ConsultancyManagement.Contract;
using ConsultancyManagement.Contract.Dto;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace ConsultancyManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserMasterController : IUserMasterAppService
    {
        private readonly IUserMasterAppService _userMasterAppService;

        public UserMasterController(IUserMasterAppService userMasterAppService)
        {
            _userMasterAppService = userMasterAppService;
        }

        [HttpPost]
        [Route("createOrUpdate")]
        public virtual Task CreateOrUpdateUser(UserMasterCreateUpdateDto input)
        {
            return _userMasterAppService.CreateOrUpdateUser(input);
        }

        [HttpDelete]
        [Route("delete")]
        public virtual Task DeleteUserAsync(int id)
        {
            return _userMasterAppService.DeleteUserAsync(id);
        }

        [HttpGet]
        [Route("getUser")]
        public virtual Task<UserMasterDto> GetUserAsync(int id)
        {
            return _userMasterAppService.GetUserAsync(id);
        }

        [HttpPost]
        [Route("fetchUserList")]
        public virtual Task<PagedResultDto<UserMasterDto>> FetchUserListAsync(GetUserInput input)
        {
            return _userMasterAppService.FetchUserListAsync(input);
        }
    }
}
