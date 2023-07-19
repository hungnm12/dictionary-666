using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.Entity
{
    
    /// Bảng cache_sql: Bảng thông tin cache_sql
    
    [System.ComponentModel.DataAnnotations.Schema.Table("cache_sql")]
    public class cache_sql : BaseEntity
    {
        
        /// Id khóa chính
        
        [System.ComponentModel.DataAnnotations.Key, ExplicitKey]
        public int cache_sql_id { get; set; }

        
        /// Key
        
        public string cache_key { get; set; }

        
        /// Value
        
        public string value { get; set; }

        
        /// Id user
        
        public Guid? user_id { get; set; }

        
        /// Loại cache
        
        public int? cache_type { get; set; }

        
        /// Thời gian bắt đầu
        
        public DateTime? start_time { get; set; }

        
        /// Thời gian hết hạn
        
        public DateTime? end_time { get; set; }
    }
}
