using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng xample_link: Bảng chứa thông tin loại liên kết example-content
    
    public class ExampleLink : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid ExampleLinkId { get; set; }

        
        /// Sys id
        
        public Guid? SysExampleLinkId { get; set; }

        
        /// Id người dùng
        
        public Guid? UserId { get; set; }

        
        /// Tên
        
        public string ExampleLinkName { get; set; }

        
        /// Loại
        
        public int? ExampleLinkType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
