﻿using H2KT.Core.Constants;
using H2KT.Core.Interfaces.Service;
using H2KT.Core.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Services
{
    
    /// Serivce xử lý session
    
    public class SessionService : ISessionService
    {
        private readonly IDistributedCacheUtil _cache;
        private readonly IConfiguration _configuration;

        public SessionService(IDistributedCacheUtil cache, IConfiguration configuration)
        {
            _cache = cache;
            _configuration = configuration;
        }

        
        /// Lấy token từ key session_id
        
        /// <param name="sessionId"></param>
        
        public string GetToken(string sessionId)
        {
            var key = string.Format(CacheKey.SessionCacheKey, sessionId);
            return _cache.Get<string>(key);
        }

        
        /// Xóa token trong cache
        
        /// <param name="sessionId"></param>
        public void RemoveToken(string sessionId)
        {
            var key = string.Format(CacheKey.SessionCacheKey, sessionId);
            _cache.Delete(key);
        }

        
        /// Cache token bằng key session_id
        
        /// <param name="sessionId"></param>
        /// <param name="token"></param>
        public void SetToken(string sessionId, string token)
        {
            var key = string.Format(CacheKey.SessionCacheKey, sessionId);
            var timeout = SecurityUtil.GetAuthTokenLifeTime(_configuration);
            _cache.Set(key, token, TimeSpan.FromMinutes(timeout));
        }

    }


}
