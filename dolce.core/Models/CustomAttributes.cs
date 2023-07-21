using H2KT.Core.Constants;
using OfficeOpenXml.Attributes;
using System;

namespace H2KT.Core.Models
{
    
    /// Thuộc tính xác định tên hiển thị của Property
    
    [AttributeUsage(AttributeTargets.Property)]
    public class MyDisplayNameAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public MyDisplayNameAttribute(string name)
        {
            this.DisplayName = name;
        }
    }

    
    /// Thuộc tính xác định Property là trường bắt buộc (không được để trống)
    
    [AttributeUsage(AttributeTargets.Property)]
    public class MyRequiredAttribute : Attribute
    {
    }

    
    /// Thuộc tính xác định Property là trường duy nhất (không được phép trùng)
    
    [AttributeUsage(AttributeTargets.Property)]
    public class MyUniqueAttribute : Attribute
    {
    }

    
    /// Thuộc tính xác định Property là trường email
    
    [AttributeUsage(AttributeTargets.Property)]
    public class MyEmailAttribute : Attribute
    {
    }

    
    /// Thuộc tính xác định Property là trường số (chỉ chấp nhận chữ số)
    
    [AttributeUsage(AttributeTargets.Property)]
    public class MyNumberAttribute : Attribute
    {
    }

    
    /// Thuộc tính xác định độ dài tối đa
    
    [AttributeUsage(AttributeTargets.Property)]
    public class MyMaxLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }

        public MyMaxLengthAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }
    }

    
    /// Thuộc tính xác định vị trí cột map mẫu nhập khẩu
    
    [AttributeUsage(AttributeTargets.Property)]
    public class ImportColumn : EpplusTableColumnAttribute
    {
        public int ColumnIndex { get; set; }


        public ImportColumn(int column) : base()
        {
            ColumnIndex = column;
            Order = column - TemplateConfig.StartColData;
        }
    }
}
