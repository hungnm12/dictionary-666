using H2KT.Core.Interfaces.Service;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using H2KT.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace H2KT.Api.Controllers
{
    public class UserController : BaseApiController
    {
        #region Fields
        private readonly IUserService _service;
        #endregion

        #region Constructor
        public UserController(INhom2ServiceCollection serviceCollection, IUserService service) : base(serviceCollection)
        {
            _service = service;
        }
        #endregion


        
        /// Lấy thông tin đăng nhập của user hiện tại
        
        
        [HttpGet("me")]
        public Task<IServiceResult> GetMe()
        {
            IServiceResult res = new ServiceResult();
            try
            {
                var user = this.ServiceCollection.AuthUtil.GetCurrentUser();
                res.Data = new
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    DictionaryId = user.DictionaryId
                };
                return Task.FromResult(res);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return Task.FromResult(res); ;
        }

        
        /// Thay đổi mật khẩu
[HttpPut("update_password")]
        public async Task<IServiceResult> UpdatePassword([FromBody] PasswordParam param)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.UpdatePassword(param.OldPassword, param.NewPassword);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Lấy thông tin cá nhân của người dùng
        
        
        [HttpGet("get_user_info")]
        public async Task<IServiceResult> GetUserInfo()
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetUserInfo();
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Cập nhật các thông tin cá nhân của người dùng
[HttpPatch("update_user_info")]
        public async Task<IServiceResult> UpdateUserInfo([FromForm] UpdateUserInfoParam param)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.UpdateUserInfo(param);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
    }
}
