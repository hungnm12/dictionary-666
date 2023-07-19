using H2KT.Core.Models.DTO;
using H2KT.Core.Models.ServerObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;

namespace H2KT.Core.Interfaces.Service
{
    
    /// Service xử lý nghiệp vụ cần call external api
    
    public interface IExternalApiService
    {
        
        /// Lấy kết quả request wordsapi
        
        /// <param name="word"></param>
        
        Task<IServiceResult> GetWordsapiResult(string word);

        
        /// Lấy kết quả request free dictionaryapi
        
        /// <param name="word"></param>
        
        Task<IServiceResult> GetFreeDictionaryApiResult(string word);
    }
}
