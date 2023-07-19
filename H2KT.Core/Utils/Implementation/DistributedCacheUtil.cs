using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Utils
{
    
    /// Lớp hỗ trợ DistributedCache
    
    public class DistributedCacheUtil : IDistributedCacheUtil
    {
        //private readonly INhom2DistributedCache _cache;
        private readonly IDistributedCache _cache;
        private readonly IWebHostEnvironment _environment;

        public DistributedCacheUtil(IDistributedCache cache, IWebHostEnvironment environment)
        {
            _cache = cache;
            _environment = environment;
        }

        
        /// Thêm string vào cache
        
        /// <param name="key">Cache key</param>
        /// <param name="value">Giá trị cần cache</param>
        /// <param name="timeout">Thời gian hết hạn</param>
        /// <param name="isAbsoluteExpiraton"></param>
        
        public async Task SetStringAsync(string key, string value, TimeSpan timeout, bool isAbsoluteExpiraton = false)
        {
            key = $"{_environment.EnvironmentName}_{key}";
            var options = new DistributedCacheEntryOptions();
            if(isAbsoluteExpiraton)
            {
                options.SetAbsoluteExpiration(timeout);
            } else
            {
                options.SetSlidingExpiration(timeout);
            }
            await _cache.SetStringAsync(key, value, options);
        }

        
        /// Thêm string vào cache, với thời gian mặc định = 20 phút
        
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="isAbsoluteExpiraton"></param>
        
        public async Task SetStringAsync(string key, string value, bool isAbsoluteExpiraton = false)
        {
            await SetStringAsync(key, value, TimeSpan.FromMinutes(20), isAbsoluteExpiraton);
        }

        
        /// Thêm object vào cache
        
        /// <param name="key">Cache key</param>
        /// <param name="value">Giá trị cần cache</param>
        /// <param name="timeout">Thời gian hết hạn</param>
        /// <param name="isAbsoluteExpiraton"></param>
        
        public async Task SetAsync(string key, object value, TimeSpan timeout, bool isAbsoluteExpiraton = false)
        {
            key = $"{_environment.EnvironmentName}_{key}";
            var options = new DistributedCacheEntryOptions();
            if (isAbsoluteExpiraton)
            {
                options.SetAbsoluteExpiration(timeout);
            }
            else
            {
                options.SetSlidingExpiration(timeout);
            }
            await _cache.SetAsync(key, value.ToBytes(), options);
        }

        
        /// Thêm object vào cache, với thời gian mặc định = 20 phút
        
        /// <param name="key">Cache key</param>
        /// <param name="value">Giá trị cần cache</param>
        /// <param name="timeout">Thời gian hết hạn</param>
        /// <param name="isAbsoluteExpiraton"></param>
        
        public async Task SetAsync(string key, object value, bool isAbsoluteExpiraton = false)
        {
            await SetAsync(key, value, TimeSpan.FromMinutes(20), isAbsoluteExpiraton);
        }

        
        /// Xóa giá trị trong cache
        
        /// <param name="key"></param>
        
        public async Task DeleteAsync(string key)
        {
            key = $"{_environment.EnvironmentName}_{key}";
            await _cache.RemoveAsync(key);
        }

        
        /// Lấy giá trị string trong cache
        
        /// <param name="key"></param>
        
        public async Task<string> GetStringAsync(string key)
        {
            key = $"{_environment.EnvironmentName}_{key}";
            return await _cache.GetStringAsync(key);
        }

        
        /// Lấy object trong cache
        
        /// <param name="key"></param>
        
        public async Task<T> GetAsync<T>(string key)
        {
            key = $"{_environment.EnvironmentName}_{key}";
            var bytes = await _cache.GetAsync(key);
            return bytes.ToObject<T>();
        }


        
        /// Thêm object vào cache
        
        /// <param name="key">Cache key</param>
        /// <param name="value">Giá trị cần cache</param>
        /// <param name="timeout">Thời gian hết hạn</param>
        /// <param name="isAbsoluteExpiraton"></param>
        
        public void Set(string key, object value, TimeSpan timeout, bool isAbsoluteExpiraton = false)
        {
            key = $"{_environment.EnvironmentName}_{key}";
            var options = new DistributedCacheEntryOptions();
            if (isAbsoluteExpiraton)
            {
                options.SetAbsoluteExpiration(timeout);
            }
            else
            {
                options.SetSlidingExpiration(timeout);
            }
            _cache.Set(key, value.ToBytes(), options);
        }

        
        /// Lấy object trong cache
        
        /// <param name="key"></param>
        
        public T Get<T>(string key)
        {
            key = $"{_environment.EnvironmentName}_{key}";
            var bytes = _cache.Get(key);
            return bytes.ToObject<T>();
        }

        
        /// Xóa giá trị trong cache
        
        /// <param name="key"></param>
        
        public void Delete(string key)
        {
            key = $"{_environment.EnvironmentName}_{key}";
            _cache.Remove(key);
        }
    }
}
