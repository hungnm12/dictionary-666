using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng sys_concept_link: Bảng thông tin liên kết concept-concept mặc định của hệ thống
    
    [System.ComponentModel.DataAnnotations.Schema.Table("sys_concept_link")]
    public class sys_concept_link : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid sys_concept_link_id { get; set; }

        
        /// Tên
        
        public string concept_link_name { get; set; }

        
        /// Loại
        
        public int? concept_link_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
