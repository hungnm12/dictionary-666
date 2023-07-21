using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Constants
{
    
    /// Giá trị mặc định của các cấu hình
    
    public static class UserConfigDataDefault
    {
        public const string ConceptLinkDefault = "No link";
        public const string ExampleLinkDefault = "No link";
        public const string ToneDefault = "Neutral";
        public const string ModeDefault = "Neutral";
        public const string RegisterDefault = "Neutral";
        public const string NuanceDefault = "Neutral";
        public const string DialectDefault = "Neutral";
    }

    
    /// Extension của file
    
    public static class FileExtension
    {
        public const string Excel2007 = ".xlsx";
        public static readonly string[] Image = {".png", ".jpeg", ".jpg"};
    }

    
    /// Loại dữ liệu của file
    
    public static class FileContentType
    {
        public const string OctetStream = "application/octet-stream";
        public const string Excel = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public static readonly string[] Image =
        {
            "image/png", 
            "image/jpeg"
        };
    }

    
    /// Đường dẫn folder storage
    
    public static class StoragePath
    {
        public const string Avatar = "avatar";
        public const string Import = "import";
    }

    
    /// Đường dẫn folder server
    
    public static class ServerStoragePath
    {
        public const string Import = "File/Import";
    }

    
    /// Hằng key cache
    
    public static class CacheKey
    {
        public const string Nhom2InstanceCache = "Nhom2";

        public const string SessionCacheKey = "session_{0}";

        public const string WordsapiNumberRequestPerDayCache = "WordsapiNumberRequestPerDay";
    }

    
    /// Giá trị xác định trước độ mạnh của liên kết
    
    public static class LinkStrength
    {
        public const int TwoPrimary = 2;
        public const int PrimaryAndAssociatedNonPrimary = 2;
        public const int TwoAssociatedNonPrimary = 1;
        public const int PrimaryAndUnAssociatedNonPrimary = 0;
        public const int TwoUnassociatedNonPrimary = -1;
        public const int Itself = 1;
    }

}
