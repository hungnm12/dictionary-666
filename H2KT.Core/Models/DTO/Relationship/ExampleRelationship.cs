using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng example_relationship: Bảng chứa liên kết example-content
    
    public class ExampleRelationship : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public int ExampleRelationshipId { get; set; }

        
        /// Id dictionary
        
        public Guid? DictionaryId { get; set; }

        
        /// Id concept
        
        public Guid? ConceptId { get; set; }

        
        /// Id example
        
        public Guid? ExampleId { get; set; }

        
        /// Id loại liên kết example-content
        
        public Guid? ExampleLinkId { get; set; }
    }
}
