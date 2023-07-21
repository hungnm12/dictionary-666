using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng sys_nuance: Bảng thông tin nuance mặc định của hệ thống
    
    public class SysNuance : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid SysNuanceId { get; set; }

        
        /// Tên
        
        public string NuanceName { get; set; }

        
        /// Loại
        
        public int? NuanceType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
