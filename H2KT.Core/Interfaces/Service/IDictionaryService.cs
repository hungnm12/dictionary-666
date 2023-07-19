using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace H2KT.Core.Interfaces.Service
{
    
    /// Service xử lý dữ liệu dictionary
    
    public interface IDictionaryService
    {
        
        /// Lấy thông tin từ điển theo id
Task<IServiceResult> GetDictionaryById(string dictionaryId);

        
        /// Lấy danh sách từ điển đã tạo của người dùng
        
        
        Task<IServiceResult> GetListDictionary();

        
        /// Truy cập vào từ điển
Task<IServiceResult> LoadDictionary(string dictionaryId);

        
        /// Thêm 1 từ điển mới 
        
        /// <param name="dictionaryName"></param>
        /// <param name="cloneDictionaryId"></param>
        
        Task<IServiceResult> AddDictionary(string dictionaryName, string cloneDictionaryId);

        
        /// Thực hiện cập nhật tên từ điển
        
        
        /// <param name="dictionaryName"></param>
        
        Task<IServiceResult> UpdateDictionary(string dictionaryId, string dictionaryName);

        
        /// Thực hiện xóa từ điển
Task<IServiceResult> DeleteDictionary(string dictionaryId);

        
        /// Thực hiện xóa dữ liệu từ điển
Task<IServiceResult> DeleteDictionaryData(string dictionaryId);

        
        /// Thực hiện copy dữ liệu từ từ điển nguồn và gộp vào dữ liệu ở từ điển đích
        
        /// <param name="sourceDictionaryId"></param>
        /// <param name="destDictionaryId"></param>
        /// <param name="isDeleteData"></param>
        
        Task<IServiceResult> TransferDictionary(string sourceDictionaryId, string destDictionaryId, bool? isDeleteData);

        
        /// Lấy số lượng concept, example trong 1 từ điển
Task<IServiceResult> GetNumberRecord(Guid dictionaryId);
    }
}
