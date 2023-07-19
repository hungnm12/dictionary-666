using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Constants
{
    
    /// Key auth
    
    public static class AuthKey
    {
        public const string Authorization = "Authorization";
        public const string Bearer = "Bearer";
        public const string TokenExpired = "Token-Expired";
        public const string SessionId = "x-session-id";
    }

    
    /// Key jwt claim
    
    public static class JwtClaimKey
    {
        public const string UserId = "UserId";
        public const string UserName = "UserName";
        public const string Email = "Email";
        public const string DictionaryId = "DictionaryId";
        public const string Status = "Status";
    }

}
