using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Utils
{
    public interface IConfigUtil
    {
        public IConfiguration Configuration { get; }

        
        /// Lấy thông tin cấu hình app setting
        
        /// <param name="name"></param>
        
        string GetAppSetting(string key, string defaultValue = null);

        
        /// Lấy thông tin API Url đã được config
        
        /// <param name="key"></param>
        
        string GetAPIUrl(string key);

        
        /// Lấy thông tin chuỗi connection string
        
        /// <param name="name"></param>
        
        string GetConnectionString(string name);
    }
}
