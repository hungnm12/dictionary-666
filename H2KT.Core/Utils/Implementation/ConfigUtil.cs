using H2KT.Core.Constants;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Utils
{
    public class ConfigUtil : IConfigUtil
    {
        #region Declaration

        private readonly IConfigurationSection _appSettings;
        private readonly IConfigurationSection _connectionStrings;
        private readonly IConfigurationSection _apiURLs;

        #endregion

        #region Properties

        public IConfiguration Configuration { get; private set; }

        #endregion

        #region Constructor

        public ConfigUtil(IConfiguration configuration)
        {
            Configuration = configuration;
            _appSettings = configuration.GetSection(AppSettingKey.AppSettingsSection);
            _connectionStrings = configuration.GetSection(AppSettingKey.ConnectionStringsSection);
            _apiURLs = configuration.GetSection(AppSettingKey.APIUrlSection);

        }

        #endregion

        #region Methods

        
        /// Lấy thông tin cấu hình app setting
        
        /// <param name="name"></param>
        
        public string GetAppSetting(string key, string defaultValue = null)
        {
            var value = _appSettings[key];
            if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(defaultValue))
            {
                value = defaultValue;
            }

            return value;
        }

        
        /// Lấy thông tin API Url đã được config
        
        /// <param name="key"></param>
        
        public string GetAPIUrl(string key)
        {
            return _apiURLs[key];
        }

        
        /// Lấy thông tin chuỗi connection string
        
        /// <param name="name"></param>
        
        public string GetConnectionString(string name)
        {
            return _connectionStrings[name];
        }

        #endregion
    }
}
