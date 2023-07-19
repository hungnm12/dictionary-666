using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng user_setting: Bảng thông tin cấu hình của người dùng
    
    public class UserSetting : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid UserSettingId { get; set; }

        
        /// Id người dùng
        
        public Guid? UserId { get; set; }

        
        /// Key
        
        public string SettingKey { get; set; }

        
        /// Value
        
        public string SettingValue { get; set; }
    }
}
