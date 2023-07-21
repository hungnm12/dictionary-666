using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng user: Bảng thông tin user
    
    [System.ComponentModel.DataAnnotations.Schema.Table("user")]
    public class user : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid user_id { get; set; }

        
        /// Tên đăng nhập
        
        public string user_name { get; set; }

        
        /// Mật khẩu
        
        public string password { get; set; }

        
        /// Email
        
        public string email { get; set; }

        
        /// Tên đầy đủ
        
        public string full_name { get; set; }

        
        /// Tên hiển thị
        
        public string display_name { get; set; }

        
        /// Vị trí, công việc
        
        public string position { get; set; }

        
        /// Ngày sinh
        
        public DateTime? birthday { get; set; }

        
        /// Link avatar
        
        public string avatar { get; set; }

        
        /// Trạng thái
        
        public int? status { get; set; }
    }
}
