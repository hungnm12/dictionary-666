using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Service
{
    
    /// Service xử lý template xuất khẩu, nhập khẩu
    
    public interface ITemplateService
    {
        
        /// Lấy template nhập khẩu
        
        
        Task<byte[]> DowloadTemplateImportDictionary();

        
        /// Xuất khẩu
        
        /// <param name="userId"></param>
        
        
        Task<byte[]> ExportDictionary(string userId, string dictionaryId);

        
        /// Backup dữ liệu và gửi vào email
        
        /// <param name="email"></param>
        
        
        Task<IServiceResult> BackupData(string email, string dictionaryId);

        
        /// Lấy tên file export
        
        /// <param name="dictionaryName"></param>
        /// <param name="dateTime"></param>
        
        string GetExportFileName(string dictionaryName, DateTime? dateTime = null);

        
        /// Nhập khẩu và validate (bước đầu)
        
        
        /// <param name="file"></param>
        
        Task<IServiceResult> ImportDictionary(string dictionaryId, IFormFile file);

        
        /// Lưu dữ liệu nhập khẩu
        
        /// <param name="importSession"></param>
        
        Task<IServiceResult> DoImport(string importSession);
    }
}
