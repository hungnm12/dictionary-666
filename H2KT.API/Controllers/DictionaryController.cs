
using H2KT.Core.Constants;
using H2KT.Core.Interfaces.Service;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Param;
using H2KT.Core.Models.ServerObject;
using H2KT.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace H2KT.Api.Controllers
{
    public class DictionaryController : BaseApiController
    {
        #region Fields
        private readonly IDictionaryService _service;
        #endregion

        #region Constructor
        public DictionaryController(INhom2ServiceCollection serviceCollection, IDictionaryService service) : base(serviceCollection)
        {
            _service = service;
        }
        #endregion
      
        /// Lấy từ điển theo id
[HttpGet("get_dictionary_by_id")]

        public async Task<IServiceResult> GetDictionaryById(string dictionaryId)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetDictionaryById(dictionaryId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        [HttpGet("get_list_dictionary")]
        public async Task<IServiceResult> GetListDictionary()
        {
            var res = new ServiceResult();
            try
            {
                return await _service.GetListDictionary();
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
        
        /// Truy cập vào từ điển
[HttpGet("load_dictionary")]

        public async Task<IServiceResult> LoadDictionary([FromQuery] string dictionaryId)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.LoadDictionary(dictionaryId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Thực hiện thêm 1 từ điển mới (có thể kèm việc copy dữ liệu từ 1 từ điển khác đã có)
[HttpPost("add_dictionary")]

        public async Task<IServiceResult> AddDictionary([FromBody] AddDictionaryParam param)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.AddDictionary(param.DictionaryName, param.CloneDictionaryId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        
        /// Thực hiện cập nhật tên từ điển
[HttpPatch("update_dictionary")]

        public async Task<IServiceResult> UpdateDictionary([FromBody] Core.Models.DTO.Dictionary param)
        {
            // param.DictionaryId null thì sẽ có exception của .NET => lỗi 400


            var res = new ServiceResult();
            try
            {
                return await _service.UpdateDictionary(param.DictionaryId.ToString(), param.DictionaryName);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

[HttpDelete("delete_dictionary")]
        public async Task<IServiceResult> DeleteDictionary([FromQuery] string dictionaryId)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.DeleteDictionary(dictionaryId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

[HttpDelete("delete_dictionary_data")]
        public async Task<IServiceResult> DeleteDictionaryData([FromQuery] string dictionaryId)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.DeleteDictionaryData(dictionaryId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        /// Thực hiện copy dữ liệu từ từ điển nguồn và gộp vào dữ liệu ở từ điển đích
[HttpPost("transfer_dictionary")]

        public async Task<IServiceResult> TransferDictionary([FromBody] TransderDictionaryParam param)
        {
            var res = new ServiceResult();
            try
            {
                return await _service.TransferDictionary(param.SourceDictionaryId, param.DestDictionaryId, param.IsDeleteData);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }

        [HttpGet("get_number_record")]
        public async Task<IServiceResult> GetNumberRecord([FromQuery] Guid? dictionaryId)
        {
            var res = new ServiceResult();
            try
            {
                if(dictionaryId == null)
                {
                    dictionaryId = this.ServiceCollection.AuthUtil.GetCurrentDictionaryId();
                }
                return await _service.GetNumberRecord((Guid)dictionaryId);
            }
            catch (Exception ex)
            {
                this.ServiceCollection.HandleControllerException(res, ex);
            }

            return res;
        }
    }
}
