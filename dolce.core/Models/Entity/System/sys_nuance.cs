using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng sys_nuance: Bảng thông tin nuance mặc định của hệ thống
    
    [System.ComponentModel.DataAnnotations.Schema.Table("sys_nuance")]
    public class sys_nuance : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid sys_nuance_id { get; set; }

        
        /// Tên
        
        public string nuance_name { get; set; }

        
        /// Loại
        
        public int? nuance_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
