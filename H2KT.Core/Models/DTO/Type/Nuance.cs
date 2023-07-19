using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng nuance: Bảng thông tin nuance
    
    public class Nuance : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid NuanceId { get; set; }

        
        /// Id bảng sys
        
        public Guid? SysNuanceId { get; set; }

        
        /// Id user
        
        public Guid? UserId { get; set; }

        
        /// Tên
        
        public string NuanceName { get; set; }

        
        /// Loại
        
        public int? NuanceType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
