using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng sys_tone: Bảng thông tin tone mặc định của hệ thống
    
    [System.ComponentModel.DataAnnotations.Schema.Table("sys_tone")]
    public class sys_tone : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid sys_tone_id { get; set; }

        
        /// Tên
        
        public string tone_name { get; set; }

        
        /// Loại
        
        public int? tone_type { get; set; }

        
        /// Thứ tự sx
        
        public int? sort_order { get; set; }
    }
}
