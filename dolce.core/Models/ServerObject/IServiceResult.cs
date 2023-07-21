using H2KT.Core.Enums;
using System;

namespace H2KT.Core.Models.ServerObject
{
    
    /// Kết quả thực hiện service
    
    public interface IServiceResult
    {
        #region Properties
        
        /// Kết quả thực hiện
        
        public ServiceResultStatus Status { get; set; }

        
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
        
        /// Hàm gọi khi thực hiện thành công
        
        /// <param name="data"></param>
        
        IServiceResult OnSuccess(object data = null, string message = null);

        
        /// Hàm gọi khi thực hiện có lỗi
        
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <param name="data"></param>
        
        IServiceResult OnError(int errorCode, string message = null, string code = null, object data = null);

        
        /// Hàm gọi khi thực hiện bị exception
        
        /// <param name="exception"></param>
        /// <param name="message"></param>
        
        IServiceResult OnException(Exception exception, string message = null);
        #endregion
    }
}
