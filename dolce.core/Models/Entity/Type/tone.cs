using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng tone: Bảng thông tin tone
    
    [System.ComponentModel.DataAnnotations.Schema.Table("tone")]
    public class tone : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid tone_id { get; set; }

        
        /// Id bảng sys
        
        public Guid? sys_tone_id { get; set; }

        
        /// Id user
        
        public Guid? user_id { get; set; }

        
        /// Tên
        
        public string tone_name { get; set; }

        
        /// Loại
        
        public int? tone_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
