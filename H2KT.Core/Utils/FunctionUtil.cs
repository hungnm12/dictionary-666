using H2KT.Core.Models;
using H2KT.Core.Models.Entity;
using H2KT.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using H2KT.Core.Constants;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace H2KT.Core.Utils
{
    
    /// Chứa các hàm hỗ trợ
    
    public static class FunctionUtil
    {
        
        /// Hàm chuyển dữ liệu kiểu List sang kiểu DataTable
        /// Có thể dùng khi debug QuickWatch
        
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="dataTableName"></param>
        
        public static DataTable ToDataTable<T>(this IList<T> items, string dataTableName = "")
        {
            var tableName = typeof(T).Name;
            if(!string.IsNullOrEmpty(dataTableName))
            {
                tableName = dataTableName;
            }

            DataTable dataTable = new DataTable(tableName);

            // Lấy tất cả properties
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach(var prop in props)
            {
                // Định nghĩa type của data column
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);

                // Đặt tên cột = tên property
                dataTable.Columns.Add(prop.Name, type);
            }

            foreach(T item in items)
            {
                var values = new object[props.Length];
                for(int i = 0; i < props.Length; ++i)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        
        /// Chuyển object sang byte[]
        
        /// <param name="obj"></param>
        
        public static byte[] ToBytes(this object obj)
        {
            if (obj == null)
            {
                return new byte[] { };
            }

            var str = SerializeUtil.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(str);
        }

        
        /// Chuyên mảng byte sang object
        
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        
        public static T ToObject<T>(this byte[] bytes)
        {
            if (bytes == null)
            {
                return default(T);
            }

            var str = Encoding.UTF8.GetString(bytes);
            return SerializeUtil.DeserializeObject<T>(str);
        }

        
        /// Snakecase to Pascal case
        
        /// <param name="str"></param>
        
        public static string ToPascalCase(this string str)
        {
            return str
                .Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1))
                .Aggregate(string.Empty, (s1, s2) => s1 + s2);

        }

        
        /// To snake case
        
        /// <param name="str"></param>
        
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        
        /// Lấy type lớp entity
        
        /// <typeparam name="T"></typeparam>
        
        public static Type GetEntityType<T>()
        {
            //if (typeof(T).IsAssignableFrom(typeof(BaseDTO)))
            //{
            //    var dtoName = typeof(T).Name;
            //    var entityName = dtoName.ToSnakeCase();
            //    return Type.GetType(entityName);
            //}
            //return typeof(T);

            var dtoName = typeof(T).Name;
            var entityName = dtoName.ToSnakeCase();
            return Type.GetType($"H2KT.Core.Models.Entity.{entityName},H2KT.Core");
        }

        
        /// Lấy type lớp DTO
        
        /// <typeparam name="T"></typeparam>
        
        public static Type GetDTOType<T>()
        {
            if (typeof(T).IsAssignableFrom(typeof(BaseEntity)))
            {
                var entityName = typeof(T).Name;
                var dtoName = entityName.ToPascalCase();
                return Type.GetType(dtoName);
            }
            return typeof(T);
        }

        
        /// Lấy ra Type của model
        
        /// <param name="typeName"></param>
        
        public static Type GetModelType(string typeName)
        {
            var ns = string.Format(
                GlobalConfig.ModelNamespace.FirstOrDefault(x => Type.GetType(string.Format(x, typeName)) != null) ?? "{0}", typeName);
            return Type.GetType(ns);
        }

        
        /// Lấy trường key của DTO
        
        /// <param name="typeName"></param>
        
        public static PropertyInfo GetDtoKeyProperty(Type dtoType)
        {
            var prop = dtoType.GetProperties().FirstOrDefault(x => Attribute.IsDefined(x, typeof(Dapper.Contrib.Extensions.KeyAttribute)));
            return prop;
        }

        
        /// Lấy trường key của entity
        
        /// <param name="typeName"></param>
        
        public static PropertyInfo GetEntityKeyProperty(Type dtoType)
        {
            var prop = dtoType.GetProperties().FirstOrDefault(x => Attribute.IsDefined(x, typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));
            return prop;
        }

        
        /// Kiểm tra kích thước file
        
        /// <param name="file"></param>
        /// <param name="maxFileSize">Kích thước file tối đa - MB</param>
        
        public static bool IsValidFileSize(IFormFile file, double maxFileSize = 3)
        {
            if(file != null && file.Length < 1024*1024* maxFileSize)
            {
                return true;
            }
            return false;
        }

        
        /// Kiểm tra loại file có phải ảnh hay không
        
        /// <param name="file"></param>
        
        public static bool IsImageFile(IFormFile file)
        {
            if (file != null && FileContentType.Image.Contains(file.ContentType))
            {
                return true;
            }
            return false;
        }

        
        /// Chuẩn hóa từ
        
        /// <param name="text"></param>
        
        public static string NormalizeText(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                return text;
            }
            text = text.Trim().ToLower();
            text = Regex.Replace(text, "[^0-9a-z ]", "");
            return text;
        }

        
        /// Lấy tên cột excel dựa trên chỉ số cột
        
        /// <param name="columnNumber"></param>
        
        public static string GetExcelColumnName(int columnNumber)
        {
            string columnName = "";

            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }

            return columnName;
        }

        
        /// Loại bỏ thẻ html khỏi string
        
        /// <param name="input"></param>
        
        public static string StripHtml(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        
        /// Kiểm tra chuỗi có đoạn highlight hay không
        
        /// <param name="str"></param>
        
        public static bool CheckStringHasHightlight(string str)
        {
            return Regex.IsMatch(str, "<h.*>.*</h>");
        }

        
        /// Sinh chuỗi highlight
        
        /// <param name="str"></param>
        
        public static string GenerateStringHightlight(string str)
        {
            return $"<h>{str}</h>";
        }
    }
}
