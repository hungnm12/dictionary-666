using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng sys_dialect: Bảng thông tin dialect mặc định của hệ thống
    
    [System.ComponentModel.DataAnnotations.Schema.Table("sys_dialect")]
    public class sys_dialect : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid sys_dialect_id { get; set; }

        
        /// Tên
        
        public string dialect_name { get; set; }

        
        /// Loại
        
        public int? dialect_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
