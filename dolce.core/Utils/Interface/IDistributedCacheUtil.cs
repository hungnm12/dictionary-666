using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Utils
{
    
    /// Interface định nghĩa lớp distributed cache
    
    public interface IDistributedCacheUtil
    {

        
        /// Thêm string vào cache
        
        /// <param name="key">Cache key</param>
        /// <param name="value">Giá trị cần cache</param>
        /// <param name="timeout">Thời gian hết hạn</param>
        /// <param name="isAbsoluteExpiraton"></param>
        
        Task SetStringAsync(string key, string value, TimeSpan timeout, bool isAbsoluteExpiraton = false);

        
        /// Thêm string vào cache, với thời gian mặc định = 20 phút
        
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="isAbsoluteExpiraton"></param>
        
        Task SetStringAsync(string key, string value, bool isAbsoluteExpiraton = false);

        
        /// Thêm object vào cache
        
        /// <param name="key">Cache key</param>
        /// <param name="value">Giá trị cần cache</param>
        /// <param name="timeout">Thời gian hết hạn</param>
        /// <param name="isAbsoluteExpiraton"></param>
        
        Task SetAsync(string key, object value, TimeSpan timeout, bool isAbsoluteExpiraton = false);

        
        /// Thêm object vào cache, với thời gian mặc định = 20 phút
        
        /// <param name="key">Cache key</param>
        /// <param name="value">Giá trị cần cache</param>
        /// <param name="timeout">Thời gian hết hạn</param>
        /// <param name="isAbsoluteExpiraton"></param>
        
        Task SetAsync(string key, object value, bool isAbsoluteExpiraton = false);

        
        /// Xóa giá trị trong cache
        
        /// <param name="key"></param>
        
        Task DeleteAsync(string key);

        
        /// Lấy giá trị string trong cache
        
        /// <param name="key"></param>
        
        Task<string> GetStringAsync(string key);

        
        /// Lấy object trong cache
        
        /// <param name="key"></param>
        
        Task<T> GetAsync<T>(string key);

        
        /// Thêm object vào cache
        
        /// <param name="key">Cache key</param>
        /// <param name="value">Giá trị cần cache</param>
        /// <param name="timeout">Thời gian hết hạn</param>
        /// <param name="isAbsoluteExpiraton"></param>
        
        void Set(string key, object value, TimeSpan timeout, bool isAbsoluteExpiraton = false);

        
        /// Lấy object trong cache
        
        /// <param name="key"></param>
        
        T Get<T>(string key);

        
        /// Xóa giá trị trong cache
        
        /// <param name="key"></param>
        void Delete(string key);
    }
}
