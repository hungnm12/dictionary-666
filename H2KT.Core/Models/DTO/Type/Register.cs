using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng register: Bảng thông tin register
    
    public class Register : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid RegisterId { get; set; }

        
        /// Id bảng sys
        
        public Guid? SysRegisterId { get; set; }

        
        /// Id user
        
        public Guid? UserId { get; set; }

        
        /// Tên
        
        public string RegisterName { get; set; }

        
        /// Loại
        
        public int? RegisterType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
