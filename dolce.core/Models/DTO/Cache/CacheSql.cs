using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng cache_sql: Bảng thông tin cache_sql
    
    public class CacheSql : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public int CacheSqlId { get; set; }

        
        /// Key
        
        public string CacheKey { get; set; }

        
        /// Value
        
        public string Value { get; set; }

        
        /// Id user
        
        public Guid? UserId { get; set; }

        
        /// Loại cache
        
        public int? CacheType { get; set; }

        
        /// Thời gian bắt đầu
        
        public DateTime? StartTime { get; set; }

        
        /// Thời gian hết hạn
        
        public DateTime? EndTime { get; set; }
    }
}
