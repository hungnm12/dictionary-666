using H2KT.Core.Constants;
using H2KT.Core.Models.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Utils
{
    
    /// Các hàm util liên quan đến authen
    
    public class AuthUtil : IAuthUtil
    {
        #region Declaration

        private readonly IHttpContextAccessor _httpContext;
        private User _user;

        #endregion

        #region Properties

        public User User => _user ??= GetCurrentUser();

        #endregion

        #region Constructor

        public AuthUtil(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        #endregion

        #region Methods

        
        /// Lấy ra đối tượng user đang đăng nhập
        
        
        public User GetCurrentUser()
        {
            var user = new User();
            if(_httpContext.HttpContext != null)
            {
                var jsonPayload = GetAuthPayloadString();
                if(!string.IsNullOrEmpty(jsonPayload))
                {
                    user = SerializeUtil.DeserializeObject<User>(jsonPayload);
                }
            }

            return user;
        }

        
        /// Lấy ra chuỗi thông tin auth từ payload của token
        
        
        private string GetAuthPayloadString()
        {
            var authHeader = GetHeaderByName(AuthKey.Authorization);
            if(!string.IsNullOrEmpty(authHeader))
            {
                string token = authHeader.Split(' ')[1];
                if(!string.IsNullOrEmpty(token))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadJwtToken(token);
                    return jsonToken.Payload.SerializeToJson();
                } 
                else
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        
        /// Lấy giá trị Header thông qua tên key
        
        /// <param name="keyName"></param>
        
        private string GetHeaderByName(string keyName)
        {
            return _httpContext?.HttpContext?.Request?.Headers[keyName] + "";
        }

        
        /// Lấy id user đang đăng nhập
        
        
        public Guid? GetCurrentUserId()
        {
            return this.User.UserId;
        }

        
        /// Lấy id dictionary đang sử dụng
        
        
        public Guid? GetCurrentDictionaryId()
        {
            return this.User.DictionaryId;
        }

        #endregion


    }
}
