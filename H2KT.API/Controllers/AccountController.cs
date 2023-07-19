using H2KT.Core.Interfaces.Service;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using H2KT.Core.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace H2KT.Api.Controllers
{
    /// api liên quan đến tài khoản ngừoi dùng
    public class AccountController : BaseApiController
    {
        #region Fields
        private readonly IAccountService _service;
        #endregion

        #region Constructors

        public AccountController(INhom2ServiceCollection serviceCollection, IAccountService service) : base(serviceCollection)
        {
            _service = service;
        }

        #endregion

        #region Methods
        /// Đăng ký tài khoản
        [HttpPost("register"), AllowAnonymous]
        public async Task<IServiceResult> Register([FromBody] AccountParam param)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.Register(param.UserName, param.Password);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
        /// Gửi link kích hoạt tài khoản
        [HttpPost("send_activate_email"), AllowAnonymous]
        public async Task<IServiceResult> SendActivateEmail([FromBody] AccountParam param)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.SendActivateEmail(param.UserName, param.Password);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
        /// Thực hiện kích hoạt tài khoản người dùng
        [HttpGet("activate_account"), AllowAnonymous]
        public async Task<IServiceResult> ActivateAccount(string token)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.ActivateAccount(token);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
        /// Đăng nhập
        [HttpPost("login"), AllowAnonymous]
        public async Task<IServiceResult> Login([FromBody] AccountParam param)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.Login(param.UserName, param.Password);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
        /// Đăng xuất
        [HttpGet("logout")]
        public async Task<IServiceResult> Logout()
        {
            var res = new ServiceResult();
            try
            {
                return await _service.Logout();
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
        /// Reset 
        [HttpGet("forgot_password"), AllowAnonymous]
        public async Task<IServiceResult> ForgotPassword(string email)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
        /// Kiểm tra quyền truy cập trang reset mật khẩu
        [HttpGet("check_access_reset_password"), AllowAnonymous]
        public async Task<IServiceResult> CheckAccessResetPassword(string token)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.CheckAccessResetPassword(token);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
        /// Reset mật khẩu cho người dùng quên mật khẩu
        [HttpPut("reset_password"), AllowAnonymous]
        public async Task<IServiceResult> ResetPassword([FromBody]PasswordParam param)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.ResetPassword(param.verificationToken, param.NewPassword);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        #endregion
    }
}
