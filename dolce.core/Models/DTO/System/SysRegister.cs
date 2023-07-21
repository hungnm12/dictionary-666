using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng sys_register: Bảng thông tin register mặc định của hệ thống
    
    public class SysRegister : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid SysRegisterId { get; set; }

        
        /// Tên
        
        public string RegisterName { get; set; }

        
        /// Loại
        
        public int? RegisterType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
