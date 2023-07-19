using H2KT.Core.Enums;
using System;

namespace H2KT.Core.Models.ServerObject
{
    
    /// Token truyền vào callback trong email
    
    public class CallbackTokenPayload
    {
        public string UserId { get; set; }

        public DateTime? TimeExpired { get; set; }
    }
}
