using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng concept_link: Bảng chứa thông tin loại liên kết concept-concept
    
    [System.ComponentModel.DataAnnotations.Schema.Table("concept_link")]
    public class concept_link : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid concept_link_id { get; set; }

        
        /// Id sys
        
        public Guid? sys_concept_link_id { get; set; }

        
        /// Id người dùng
        
        public Guid? user_id { get; set; }

        
        /// Tên
        
        public string concept_link_name { get; set; }

        
        /// Loại
        
        public int? concept_link_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
