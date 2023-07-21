using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng sys_register: Bảng thông tin register mặc định của hệ thống
    
    [System.ComponentModel.DataAnnotations.Schema.Table("sys_register")]
    public class sys_register : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid sys_register_id { get; set; }

        
        /// Tên
        
        public string register_name { get; set; }

        
        /// Loại
        
        public int? register_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
