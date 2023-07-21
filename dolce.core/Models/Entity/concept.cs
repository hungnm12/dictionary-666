using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng concept: Bảng chứa thông tin concept
    
    [System.ComponentModel.DataAnnotations.Schema.Table("concept")]
    public class concept : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public Guid concept_id { get; set; }

        
        /// Id dictionary
        
        public Guid? dictionary_id { get; set; }

        
        /// Tên
        
        public string title { get; set; }

        
        /// Mô tả/định nghĩa
        
        public string description { get; set; }

        
        /// Title được chuẩn hóa
        
        // public string normalized_title { get; set; }

        
        /// Giá trị soundex của title
        
        // public string soundex_title { get; set; }
    }
}
