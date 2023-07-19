using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng tone: Bảng thông tin tone
    
    public class Tone : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid ToneId { get; set; }

        
        /// Id bảng sys
        
        public Guid? SysToneId { get; set; }

        
        /// Id user
        
        public Guid? UserId { get; set; }

        
        /// Tên
        
        public string ToneName { get; set; }

        
        /// Loại
        
        public int? ToneType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
