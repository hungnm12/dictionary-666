using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng mode: Bảng thông tin mode
    
    [System.ComponentModel.DataAnnotations.Schema.Table("mode")]
    public class mode : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid mode_id { get; set; }

        
        /// Id bảng sys
        
        public Guid? sys_mode_id { get; set; }

        
        /// Id user
        
        public Guid? user_id { get; set; }

        
        /// Tên
        
        public string mode_name { get; set; }

        
        /// Loại
        
        public int? mode_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
