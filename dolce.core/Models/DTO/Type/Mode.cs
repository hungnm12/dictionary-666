using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng mode: Bảng thông tin mode
    
    public class Mode : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid ModeId { get; set; }

        
        /// Id bảng sys
        
        public Guid? SysModeId { get; set; }

        
        /// Id user
        
        public Guid? UserId { get; set; }

        
        /// Tên
        
        public string ModeName { get; set; }

        
        /// Loại
        
        public int? ModeType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
