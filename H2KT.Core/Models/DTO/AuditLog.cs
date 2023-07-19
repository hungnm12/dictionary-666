using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng audit_log: Bảng chứa thông tin lịch sử truy cập
    
    public class AuditLog : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public int AuditLogId { get; set; }

        
        /// Id người dùng
        
        public Guid? UserId { get; set; }

        
        /// Thông tin màn hình/Tên màn hình
        
        public string ScreenInfo { get; set; }

        
        /// Loại hành động
        
        public int? ActionType { get; set; }

        
        /// Thông tin tham chiếu, vd: id dictionary đang thao tác
        
        public string Reference { get; set; }

        
        /// Mô tả
        
        public string Description { get; set; }

        
        /// Thông tin user agent
        
        public string UserAgent { get; set; }

    }
}
