using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng sys_dialect: Bảng thông tin dialect mặc định của hệ thống
    
    public class SysDialect : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid SysDialectId { get; set; }

        
        /// Tên
        
        public string DialectName { get; set; }

        
        /// Loại
        
        public int? DialectType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
