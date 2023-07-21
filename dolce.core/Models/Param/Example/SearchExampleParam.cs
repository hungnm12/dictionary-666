using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Models.Param
{
    
    /// Param tìm kiếm example
    
    public class SearchExampleParam
    {
        public Guid? DictionaryId { get; set; }
        public string Keyword { get; set; }
        public string ToneId { get; set; }
        public string ModeId { get; set; }
        public string RegisterId { get; set; }
        public string NuanceId { get; set; }
        public string DialectId { get; set; }

        public List<string> ListLinkedConceptId { get; set; }

        
        /// Tìm kiếm example không liên kết concept
        
        public bool? IsSearchUndecided { get; set; }

        
        /// Sử dụng fulltext search trong mysql
        
        public bool? IsFulltextSearch { get; set; }
    }
}
