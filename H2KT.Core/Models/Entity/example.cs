using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng example: Bảng chứa thông tin example
    
    [System.ComponentModel.DataAnnotations.Schema.Table("example")]
    public class example : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid example_id { get; set; }

        
        /// Id dictionary
        
        public Guid? dictionary_id { get; set; }

        
        /// Id tone
        
        public Guid? tone_id { get; set; }

        
        /// Id register
        
        public Guid? register_id { get; set; }

        
        /// Id dialect
        
        public Guid? dialect_id { get; set; }

        
        /// Id mode
        
        public Guid? mode_id { get; set; }

        
        /// Id nuance
        
        public Guid? nuance_id { get; set; }

        
        /// Ghi chú
        
        public string note { get; set; }

        
        /// Nội dung ví dụ
        
        public string detail { get; set; }

        
        /// Nội dung ví dụ dạng html
        
        public string detail_html { get; set; }
    }
}
