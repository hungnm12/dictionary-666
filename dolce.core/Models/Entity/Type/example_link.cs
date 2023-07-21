using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng example_link: Bảng chứa thông tin loại liên kết example-content
    
    [System.ComponentModel.DataAnnotations.Schema.Table("example_link")]
    public class example_link : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid example_link_id { get; set; }

        
        /// Sys id
        
        public Guid? sys_example_link_id { get; set; }

        
        /// Id người dùng
        
        public Guid? user_id { get; set; }

        
        /// Tên
        
        public string example_link_name { get; set; }

        
        /// Loại
        
        public int? example_link_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
