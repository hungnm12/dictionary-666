using H2KT.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Utils
{
    
    /// Các hàm util liên quan đến authen
    
    public interface IAuthUtil
    {
        
        /// Lấy ra đối tượng User đang đăng nhập
        
        
        User GetCurrentUser();

        
        /// Lấy id user đang đăng nhập
        
        
        Guid? GetCurrentUserId();

        
        /// Lấy id dictionary đang sử dụng
        
        
        Guid? GetCurrentDictionaryId();

    }
}
