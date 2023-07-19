using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng sys_ConceptLink: Bảng thông tin liên kết concept-concept mặc định của hệ thống
    
    public class SysConceptLink : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid SysConceptLinkId { get; set; }

        
        /// Tên
        
        public string ConceptLinkName { get; set; }

        
        /// Loại
        
        public int? ConceptLinkType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
