using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng concept_relationship: Bảng chứa liên kết concept-concept
    
    public class ConceptRelationship : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public int ConceptRelationshipId { get; set; }

        
        /// Id dictionary
        
        public Guid? DictionaryId { get; set; }

        
        /// Id concept con
        
        public Guid? ConceptId { get; set; }

        
        /// Id concept cha
        
        public Guid? ParentId { get; set; }

        
        /// Id loại liên kết concept-concept
        
        public Guid? ConceptLinkId { get; set; }
    }
}
