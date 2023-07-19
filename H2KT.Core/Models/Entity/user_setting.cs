using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng user_setting: Bảng thông tin cấu hình của người dùng
    
    [System.ComponentModel.DataAnnotations.Schema.Table("user_setting")]
    public class user_setting : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid user_setting_id { get; set; }

        
        /// Id người dùng
        
        public Guid? user_id { get; set; }

        
        /// Key
        
        public string setting_key { get; set; }

        
        /// Value
        
        public string setting_value { get; set; }
    }
}
