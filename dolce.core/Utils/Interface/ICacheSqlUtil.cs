using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Utils
{
    public interface ICacheSqlUtil
    {
        
        /// Thêm dữ liệu vào cahce cache
        
        /// <param name="cacheKey">Cache key</param>
        /// <param name="cacheValue">Giá trị cần cache</param>
        /// <param name="cacheType">Loại cache</param>
        /// <param name="timeout">Thời gian hết hạn</param>
        /// <param name="isSystem">Là cache hệ thống hay cache user</param>
        /// <param name="transaction"></param>
        
        Task<bool> SetCache(string cacheKey, string cacheValue, int? cacheType, TimeSpan? timeout = null, bool? isSystem = null, IDbTransaction transaction = null);

        
        /// Xóa giá trị trong cache
        
        /// <param name="cacheKey"></param>
        /// <param name="transaction"></param>
        
        Task<bool> DeleteCache(string cacheKey, IDbTransaction transaction = null);

        
        /// Xóa giá trị trong cache với tham số truyền vào
        
        
        /// <param name="transaction"></param>
        
        Task<bool> DeleteCache(object param, IDbTransaction transaction = null);

        
        /// Cập nhật chỉ dữ liệu cache (không thay đổi thời gian cache)
        
        /// <param name="param">anynomous object phải chứa key</param>
        
        Task<bool> UpdateOnlyCacheValue(string cacheKey, string cacheValue, IDbTransaction transaction = null);

        
        /// Lấy dữ liệu trong cache
        
        /// <param name="cacheKey"></param>
        
        Task<string> GetCache(string cacheKey);
    }
}
