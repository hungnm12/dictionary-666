using H2KT.Core.Enums;
using H2KT.Core.Models.DTO;
using System;
using System.Collections.Generic;

namespace H2KT.Core.Models.ServerObject
{
    
    /// Dữ liệu valid sau bước đầu (sau validate) nhập khẩu
    
    public class CacheImportResult
    {
        public Guid DictionaryId { get; set; }
        public int NumberValidRecord { get; set; }
        public List<Concept> ListConcept { get; set; }
        public List<Example> ListExample { get; set; }
        public List<ConceptRelationship> ListConceptRelationship { get; set; }
        public List<ExampleRelationship> ListExampleRelationship { get; set; }
    }
}
