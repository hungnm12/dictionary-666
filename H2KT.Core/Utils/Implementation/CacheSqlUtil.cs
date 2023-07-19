using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Utils
{
    
    /// Lớp hỗ trợ cache dữ liệu vào database
    
    public class CacheSqlUtil : ICacheSqlUtil
    {
        private ICacheSqlRepository _repository;
        private INhom2ServiceCollection _serviceCollection;
        public CacheSqlUtil(ICacheSqlRepository repository, INhom2ServiceCollection serviceCollection)
        {
            _repository = repository;
            _serviceCollection = serviceCollection;
        }

        
        /// Thêm dữ liệu vào cahce cache
        
        /// <param name="cacheKey">Cache key</param>
        /// <param name="cacheValue">Giá trị cần cache</param>
        /// <param name="cacheType">Loại cache</param>
        /// <param name="timeout">Thời gian hết hạn</param>
        /// <param name="transaction"></param>
        
        public async Task<bool> SetCache(string cacheKey, string cacheValue, int? cacheType, TimeSpan? timeout = null, bool? isSystem = null, IDbTransaction transaction = null)
        {
            if(timeout == null)
            {
                timeout = TimeSpan.FromMinutes(60);
            }
            var startTime = DateTime.Now;
            var endTime = startTime + timeout;
            var cache = new cache_sql
            {
                cache_key = cacheKey,
                value = cacheValue,
                user_id = isSystem == true ? null : this._serviceCollection.AuthUtil.GetCurrentUserId(),
                cache_type = cacheType,
                start_time = startTime,
                end_time = endTime
            };

            if(transaction != null)
            {
                await _repository.Insert(cache, transaction);
            } else
            {
                await _repository.Insert(cache);
            }
            
            return true;
        }

        
        /// Xóa giá trị trong cache
        
        /// <param name="cacheKey"></param>
        /// <param name="transaction"></param>
        
        public async Task<bool> DeleteCache(string cacheKey, IDbTransaction transaction = null)
        {
            await _repository.Delete(new {
                cache_key = cacheKey
            }, transaction);
            return true;
        }

        
        /// Xóa giá trị trong cache với tham số truyền vào
        
        
        /// <param name="transaction"></param>
        
        public async Task<bool> DeleteCache(object param, IDbTransaction transaction = null)
        {
            await _repository.Delete(param, transaction);
            return true;
        }

        
        /// Cập nhật chỉ dữ liệu cache (không thay đổi thời gian cache)
        
        /// <param name="param">anynomous object phải chứa key</param>
        
        public async Task<bool> UpdateOnlyCacheValue(string cacheKey, string cacheValue, IDbTransaction transaction = null)
        {
            var item = await _repository.SelectObject<CacheSql>(new 
            { 
                cache_key = cacheKey
            }) as CacheSql;

            if(item == null)
            {
                return false;
            }

            var updateParam = new
            {
                cache_sql_id = item.CacheSqlId,
                value = cacheValue
            };
            return await _repository.Update(updateParam, transaction);
        }

        
        /// Lấy dữ liệu trong cache
        
        /// <param name="cacheKey"></param>
        
        public async Task<string> GetCache(string cacheKey)
        {
            var cache = await _repository.SelectObject<CacheSql>(new
            {
                cache_key = cacheKey
            }) as CacheSql;
            return cache?.Value;
        }
    }
}
