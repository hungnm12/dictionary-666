using H2KT.Core.Models.DTO;
using H2KT.Core.Models.ServerObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Service
{
    
    /// Service xử lý config (concept link, example link, tone, mode...)
    
    public interface IUserConfigService
    {
        
        /// Lấy danh sách tất cả config: 
        
        /// <param name="userId"></param>
        
        Task<UserConfigData> GetAllConfigData(string userId = null);

        
        /// Lấy danh sách concept link
        
        
        Task<IServiceResult> GetListConceptLink();

        
        /// Lấy danh sách example link
        
        
        Task<IServiceResult> GetListExampleLink();

        
        /// Lấy danh sách example attribute
        
        
        Task<IServiceResult> GetListExampleAttribute();

    }
}
