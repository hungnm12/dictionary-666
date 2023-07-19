using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng sys_tone: Bảng thông tin tone mặc định của hệ thống
    
    public class SysTone : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid SysToneId { get; set; }

        
        /// Tên
        
        public string ToneName { get; set; }

        
        /// Loại
        
        public int? ToneType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
