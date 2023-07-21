using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng sys_mode: Bảng thông tin mode mặc định của hệ thống
    
    [System.ComponentModel.DataAnnotations.Schema.Table("sys_mode")]
    public class sys_mode : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid sys_mode_id { get; set; }

        
        /// Tên
        
        public string mode_name { get; set; }

        
        /// Loại
        
        public int? mode_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
