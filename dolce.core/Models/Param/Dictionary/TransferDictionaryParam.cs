using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Models.Param
{
    
    /// Param cho api transfer_dictionary
    
    public class TransderDictionaryParam
    {
        public string SourceDictionaryId { get; set; }
        public string DestDictionaryId { get; set; }

        
        /// Có xóa dữ liệu trước khi chuyển dữ liệu hay không
        
        public bool? IsDeleteData { get; set; }
    }
}
