using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng sys_mode: Bảng thông tin mode mặc định của hệ thống
    
    public class SysMode : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid SysModeId { get; set; }

        
        /// Tên
        
        public string ModeName { get; set; }

        
        /// Loại
        
        public int? ModeType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
