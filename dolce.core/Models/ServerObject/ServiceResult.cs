using H2KT.Core.Constants;
using H2KT.Core.Enums;
using System;

namespace H2KT.Core.Models.ServerObject
{
    
    /// Kết quả thực hiện service
    
    public class ServiceResult : IServiceResult
    {
        #region Properties
        
        /// Kết quả thực hiện
        
        public ServiceResultStatus Status { get; set; } = ServiceResultStatus.Success;

        
        /// Dữ liệu trả về
        
        public object Data { get; set; }

        
        /// Thông báo
        
        public string Message { get; set; }

        
        /// Thông báo cho dev
        
        public string DevMessage { get; set; }

        
        /// Mã lỗi (string)
        
        public string Code { get; set; }

        
        /// Mã lỗi (số)
        
        public int ErrorCode { get; set; }
        #endregion

        #region Constructors

        #endregion

        #region Methods

        public IServiceResult OnSuccess(object data = null, string message = null)
        {
            this.Status = ServiceResultStatus.Success;
            this.Data = data;
            this.Message = message;
            return this;
        }

        public IServiceResult OnError(int errorCode, string message = null, string code = null, object data = null)
        {
            this.Status = ServiceResultStatus.Fail;
            this.Data = data;
            this.ErrorCode = errorCode;
            this.Message = message;
            this.Code = code;
            return this;
        }

        public IServiceResult OnException(Exception exception, string message = null)
        {
            this.Status = ServiceResultStatus.Exception;

            if(GlobalConfig.IsDevelopment)
            {
                this.DevMessage = $"{this.Message} {exception.Message}";
            }
            
            return this;
        }
        #endregion
    }
}
