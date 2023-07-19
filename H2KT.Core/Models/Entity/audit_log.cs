using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng audit_log: Bảng chứa thông tin lịch sử truy cập
    
    [System.ComponentModel.DataAnnotations.Schema.Table("audit_log")]
    public class audit_log : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public int audit_log_id { get; set; }

        
        /// Id người dùng
        
        public Guid? user_id { get; set; }

        
        /// Thông tin màn hình/Tên màn hình
        
        public string screen_info { get; set; }

        
        /// Loại hành động
        
        public int? action_type { get; set; }

        
        /// Thông tin tham chiếu, vd: id dictionary đang thao tác
        
        public string reference { get; set; }

        
        /// Mô tả
        
        public string description { get; set; }

        
        /// Thông tin user agent
        
        public string user_agent { get; set; }

    }
}
