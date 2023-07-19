using H2KT.Core.Models.ServerObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Service
{
    
    /// Interface BL xử lý session
    
    public interface ISessionService
    {
        
        /// Set cache
        
        /// <param name="sessionId"></param>
        /// <param name="token"></param>
        void SetToken(string sessionId, string token);

        
        /// Get cache
        
        /// <param name="sessionId"></param>
        
        string GetToken(string sessionId);

        
        /// Xóa cache
        
        void RemoveToken(string sessionId);
    }
}
