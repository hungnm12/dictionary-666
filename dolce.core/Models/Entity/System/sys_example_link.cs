using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng sys_example_link: Bảng thông tin liên kết example-concept mặc định của hệ thống
    
    [System.ComponentModel.DataAnnotations.Schema.Table("sys_example_link")]
    public class sys_example_link : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid sys_example_link_id { get; set; }

        
        /// Tên
        
        public string example_link_name { get; set; }

        
        /// Loại
        
        public int? example_link_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
