using Newtonsoft.Json;
using System;

namespace H2KT.Core.Utils
{
    
    /// Lớp xử lý các hành động chuyển dữ liệu giữa Object và String
    
    public static class SerializeUtil
    {
        public static readonly DateFormatHandling JSONDateFormatHandling = DateFormatHandling.IsoDateFormat;
        public static readonly DateTimeZoneHandling JSONDateTimeZoneHandling = DateTimeZoneHandling.Local;
        public static readonly string JSONDateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffFFFFK";
        public static readonly NullValueHandling JSONNullValueHandling = NullValueHandling.Include;
        public static readonly ReferenceLoopHandling JSONReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        
        /// Custom lại format
        
        
        public static JsonSerializerSettings GetJsonSerializerSetting()
        {
            return new JsonSerializerSettings()
            {
                DateFormatHandling = JSONDateFormatHandling,
                DateTimeZoneHandling = JSONDateTimeZoneHandling,
                DateFormatString = JSONDateFormatString,
                NullValueHandling = JSONNullValueHandling,
                ReferenceLoopHandling = JSONReferenceLoopHandling
            };
        }

        
        /// Hàm chuyển object sang json
        
        /// <param name="data"></param>
        
        public static string SerializeObject(object data)
        {
            return JsonConvert.SerializeObject(data, GetJsonSerializerSetting());
        }

        
        /// Hàm chuyển json sang object thuộc kiểu T
        
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        
        public static T DeserializeObject<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data, GetJsonSerializerSetting());
        }

        
        /// Hàm chuyển json sang object
        
        /// <param name="data"></param>
        /// <param name="objectType"></param>
        
        public static object DeserializeObject(string data, Type objectType)
        {
            return JsonConvert.DeserializeObject(data, objectType, GetJsonSerializerSetting());
        }

    }
}