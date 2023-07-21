using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng register: Bảng thông tin register
    
    [System.ComponentModel.DataAnnotations.Schema.Table("register")]
    public class register : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid register_id { get; set; }

        
        /// Id bảng sys
        
        public Guid? sys_register_id { get; set; }

        
        /// Id user
        
        public Guid? user_id { get; set; }

        
        /// Tên
        
        public string register_name { get; set; }

        
        /// Loại
        
        public int? register_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
