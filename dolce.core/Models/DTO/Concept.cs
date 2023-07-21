using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng concept: Bảng chứa thông tin concept
    
    public class Concept : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid ConceptId { get; set; }

        
        /// Id dictionary
        
        public Guid? DictionaryId { get; set; }

        
        /// Tên
        
        public string Title { get; set; }

        
        /// Mô tả/định nghĩa
        
        public string Description { get; set; }

        
        /// Title được chuẩn hóa
        
        // public string NormalizedTitle { get; set; }

        
        /// Giá trị soundex của title
        
        // public string SoundexTitle { get; set; }
    }
}
