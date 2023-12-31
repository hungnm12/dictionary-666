﻿using H2KT.Core.Constants;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace H2KT.Core.Models.ServerObject
{
    
    /// Đối tượng xuất/nhập khẩu: map với view_example
    
    public class ExampleImport : BaseImport
    {
        [ImportColumn(TemplateConfig.ExampleSheet.Example)]
        public string DetailHtml { get; set; }

        [ImportColumn(TemplateConfig.ExampleSheet.Tone)]
        public string ToneName { get; set; }

        [ImportColumn(TemplateConfig.ExampleSheet.Mode)]
        public string ModeName { get; set; }

        [ImportColumn(TemplateConfig.ExampleSheet.Register)]
        public string RegisterName { get; set; }

        [ImportColumn(TemplateConfig.ExampleSheet.Nuance)]
        public string NuanceName { get; set; }

        [ImportColumn(TemplateConfig.ExampleSheet.Dialect)]
        public string DialectName { get; set; }

        [ImportColumn(TemplateConfig.ExampleSheet.Note)]
        public string Note { get; set; }

        
        /// Validate nhập khẩu
        
        /// <param name="lstExistExample">Danh sách example đã tồn tại</param>
        /// <param name="findTone"></param>
        /// <param name="findMode"></param>
        /// <param name="findRegister"></param>
        /// <param name="findNuance"></param>
        /// <param name="findDialect"></param>
        
        public ValidateResultImport ValidateBusinessMater(List<Example> lstExistExample,
            tone findTone, mode findMode, register findRegister, nuance findNuance, dialect findDialect)
        {
            var res = new ValidateResultImport
            {
                IsValid = true,
                Row = RowIndex,
                ListErrorMessage = new List<string>()
            };

            // Validate example
            if (string.IsNullOrEmpty(DetailHtml))
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.Required, "Example"));
            }

            if (lstExistExample.Any(x => x.DetailHtml == DetailHtml))
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.Duplicated, "Example"));
            }

            // Validate tone, mode, register, nuance, dialect
            if (!string.IsNullOrEmpty(ToneName) && findTone == null)
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.NotExist, "Tone"));
            }

            if (!string.IsNullOrEmpty(ModeName) && findMode == null)
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.NotExist, "Mode"));
            }

            if (!string.IsNullOrEmpty(RegisterName) && findRegister == null)
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.NotExist, "Register"));
            }

            if (!string.IsNullOrEmpty(NuanceName) && findNuance == null)
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.NotExist, "Nuance"));
            }

            if (!string.IsNullOrEmpty(DialectName) && findDialect == null)
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.NotExist, "Dialect"));
            }

            return res;
        }
    }
}
