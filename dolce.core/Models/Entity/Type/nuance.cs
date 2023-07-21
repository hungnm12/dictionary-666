using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng nuance: Bảng thông tin nuance
    
    [System.ComponentModel.DataAnnotations.Schema.Table("nuance")]
    public class nuance : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid nuance_id { get; set; }

        
        /// Id bảng sys
        
        public Guid? sys_nuance_id { get; set; }

        
        /// Id user
        
        public Guid? user_id { get; set; }

        
        /// Tên
        
        public string nuance_name { get; set; }

        
        /// Loại
        
        public int? nuance_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
