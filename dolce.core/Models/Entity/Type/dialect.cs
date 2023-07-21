using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng dialect: Bảng thông tin dialect
    
    [System.ComponentModel.DataAnnotations.Schema.Table("dialect")]
    public class dialect : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid dialect_id { get; set; }

        
        /// Id bảng sys
        
        public Guid? sys_dialect_id { get; set; }

        
        /// Id user
        
        public Guid? user_id { get; set; }

        
        /// Tên
        
        public string dialect_name { get; set; }

        
        /// Loại
        
        public int? dialect_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
