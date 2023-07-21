using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng example_relationship: Bảng chứa liên kết example-content
    
    [System.ComponentModel.DataAnnotations.Schema.Table("example_relationship")]
    public class example_relationship : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public int example_relationship_id { get; set; }

        
        /// Id dictionary
        
        public Guid? dictionary_id { get; set; }

        
        /// Id concept
        
        public Guid? concept_id { get; set; }

        
        /// Id example
        
        public Guid? example_id { get; set; }

        
        /// Id loại liên kết example-content
        
        public Guid? example_link_id { get; set; }
    }
}
