using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng concept_link: Bảng chứa thông tin loại liên kết concept-concept
    
    public class ConceptLink : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid ConceptLinkId { get; set; }

        
        /// Id sys
        
        public Guid? SysConceptLinkId { get; set; }

        
        /// Id người dùng
        
        public Guid? UserId { get; set; }

        
        /// Tên
        
        public string ConceptLinkName { get; set; }

        
        /// Loại
        
        public int? ConceptLinkType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
