using H2KT.Core.Enums;
using System;
using System.Collections.Generic;

namespace H2KT.Core.Models.ServerObject
{
    
    /// Kết quả bước đầu (sau validate) nhập khẩu
    
    public class TempImportResult
    {
        public string ImportSession { get; set; }
        public int NumberValid { get; set; }
        public int NumberError { get; set; }
        public List<ValidateResultImport> ListValidateError { get; set; }
        public string StrFileError { get; set; }
    }
}
