using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng concept_relationship: Bảng chứa liên kết concept-concept
    
    [System.ComponentModel.DataAnnotations.Schema.Table("concept_relationship")]
    public class concept_relationship : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public int concept_relationship_id { get; set; }

        
        /// Id dictionary
        
        public Guid? dictionary_id { get; set; }

        
        /// Id concept con
        
        public Guid? concept_id { get; set; }

        
        /// Id concept cha
        
        public Guid? parent_id { get; set; }

        
        /// Id loại liên kết concept-concept
        
        public Guid? concept_link_id { get; set; }
    }
}
