using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Models.Param
{
    
    /// Param xử lý cập nhật thông tin người dùng
    
    public class UpdateUserInfoParam
    {
        public IFormFile Avatar { get; set; }
        public string DisplayName { get; set; }
        public string FullName { get; set; }
        public string Birthday { get; set; }
        public string Position { get; set; }
    }
}
