using Dapper.Contrib.Extensions;
using System;

namespace H2KT.Core.Models.DTO
{
    
    /// Bảng sys_example_link: Bảng thông tin liên kết example-concept mặc định của hệ thống
    
    public class SysExampleLink : BaseDTO
    {
        
        /// Id khóa chính
        
        [Key]
        public Guid SysExampleLinkId { get; set; }

        
        /// Tên
        
        public string ExampleLinkName { get; set; }

        
        /// Loại
        
        public int? ExampleLinkType { get; set; }

        
        /// Thứ tự sx
        
        public int? SortOrder { get; set; }
    }
}
