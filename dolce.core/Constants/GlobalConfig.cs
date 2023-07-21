using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Constants
{
    
    /// Cấu hình global namespace
    
    public static class GlobalConfig
    {
        public static string Environment = null;
        public static bool IsDevelopment = false;
        public static string ContentRootPath = "";

        public static readonly int ConnectionTimeout = 999;

        public static readonly string[] ModelNamespace =
        { 
            "H2KT.Core.Models.DTO.{0}, H2KT.Core",
            "H2KT.Core.Models.Entity.{0}, H2KT.Core",
        };

        public static readonly string[] ServiceNamespace =
        {
            "H2KT.Core.Models.Services.{0}, H2KT.Core",
        };

        public static readonly string[] RepositoryNamespace =
        {
            "H2KT.Infrastructure.Repositories.{0}, H2KT.Infrastructure",
        };
    }

}
