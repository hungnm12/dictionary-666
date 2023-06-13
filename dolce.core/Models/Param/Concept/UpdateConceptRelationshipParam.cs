﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Models.Param
{
    
    /// Param cho api update_concept_relationship
    
    public class UpdateConceptRelationshipParam
    {
        public Guid ConceptId { get; set; }
        public Guid ParentId { get; set; }
        public Guid? ConceptLinkId { get; set; }
        public bool? IsForced { get; set; }

    }
}
