using H2KT.Core.Models.DTO;
using H2KT.Core.Models.ServerObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Service
{
    
    /// Interface BL xử lý account
    
    public interface IAccountService
    {
        
        /// Xử lý đăng ký tài khoản
        
        /// <param name="userName"></param>
        /// <param name="password"></param>
        
        Task<IServiceResult> Register(string userName, string password);

        
        /// Xử lý yêu cầu gửi email xác minh tài khoản
        
        /// <param name="userName"></param>
        /// <param name="password"></param>
        
        Task<IServiceResult> SendActivateEmail(string userName, string password);

        
        /// Thực hiện kích hoạt tài khoản người dùng
        
        /// <param name="token">Token kích hoạt</param>
        
        Task<IServiceResult> ActivateAccount(string token);

        
        /// Xử lý login
        
        /// <param name="userName"></param>
        /// <param name="password"></param>
        
        Task<IServiceResult> Login(string userName, string password);

        
        /// Xử lý logout
        
        
        Task<IServiceResult> Logout();


        
        /// Xử lý gửi email hệ thống chứa link reset mật khẩu tới email mà người dung cung cấp
        
        /// <param name="email"></param>
        
        Task<IServiceResult> ForgotPassword(string email);

        
        /// Kiểm tra quyền truy cập trang reset mật khẩu
        
        /// <param name="token"></param>
        
        Task<IServiceResult> CheckAccessResetPassword(string token);

        
        /// Xử lý Reset mật khẩu cho người dùng quên mật khẩu.
        
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        
        Task<IServiceResult> ResetPassword(string token, string newPassword);


        // TODO: 3 method bên dưới cần xem xét lại sự phù hợp với interface này

        
        /// Sinh session mới
        
        /// <param name="user"></param>
        string GenerateSession(User user);

        
        /// Xóa session cũ
        
        void RemoveCurrentSession();

        
        /// Set session cho request response hiện tại
        
        /// <param name="sessionId"></param>
        void SetResponseSessionCookie(string sessionId);

        #region Helper
        
        /// Lấy key cache throttle hạn chế thời gian call api
        
        
        string GetThrottleCacheKey(string name);

        
        /// Kiểm tra thời gian cần chờ trước khi call api liên tục
        
        /// <param name="name"></param>
        /// <param name="seconds"></param>
        
        double GetThrottleTime(string name);

        
        /// Set thời gian chặn call api liên tục
        
        /// <param name="name"></param>
        /// <param name="seconds"></param>
        void SetThrottleTime(string name, int seconds = 120);
        #endregion
    }
}
