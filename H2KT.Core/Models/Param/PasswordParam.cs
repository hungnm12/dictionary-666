using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Models.Param
{
    
    /// Param xử lý reset mật khẩu
    
    public class PasswordParam
    {
        public string verificationToken{ get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
