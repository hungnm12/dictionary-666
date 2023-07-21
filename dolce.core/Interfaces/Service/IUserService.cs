using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Service
{
    
    /// Service xử lý dữ liệu user
    
    public interface IUserService
    {
        
        /// Thay đổi mật khẩu
        
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        
        Task<IServiceResult> UpdatePassword(string oldPassword, string newPassword);

        
        /// Lấy các thông tin cá nhân của người dùng
        
        
        Task<IServiceResult> GetUserInfo();

        
        /// Cập nhật các thông tin cá nhân của người dùng
        Task<IServiceResult> UpdateUserInfo(UpdateUserInfoParam param);
            }
        }
