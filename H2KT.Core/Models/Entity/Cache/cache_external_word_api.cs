using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng cache_external_word_api: Bảng thông tin cache_external_word_api
    
    [System.ComponentModel.DataAnnotations.Schema.Table("cache_external_word_api")]
    public class cache_external_word_api : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public int id { get; set; }

        
        /// Từ
        
        public string word { get; set; }

        
        /// Route api
        
        public string route { get; set; }

        
        /// Loại api
        
        public int external_api_type { get; set; }

        
        /// Giá trị cache
        
        public string value { get; set; }
    }
}
