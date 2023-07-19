using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng dialect: Bảng thông tin dialect
    
    public class Dialect : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid DialectId { get; set; }

        
        /// Id bảng sys
        
        public Guid? SysDialectId { get; set; }

        
        /// Id user
        
        public Guid? UserId { get; set; }

        
        /// Tên
        
        public string DialectName { get; set; }

        
        /// Loại
        
        public int? DialectType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
