using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng cache_external_word_api: Bảng thông tin cache_external_word_api
    
    public class CacheExternalWordApi : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public int Id { get; set; }

        
        /// Từ
        
        public string Word { get; set; }

        
        /// Route api
        
        public string Route { get; set; }

        
        /// Loại api
        
        public int ExternalApiType { get; set; }

        
        /// Giá trị cache
        
        public string Value { get; set; }
    }
}
