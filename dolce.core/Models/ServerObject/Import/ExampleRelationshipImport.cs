﻿using H2KT.Core.Constants;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace H2KT.Core.Models.ServerObject
{
    
    /// Đối tượng xuất/nhập khẩu: map với view_example_relationship
    
    public class ExampleRelationshipImport : BaseImport
    {
        [ImportColumn(TemplateConfig.ExampleRelationshipSheet.Example)]
        public string ExampleHtml { get; set; }

        [ImportColumn(TemplateConfig.ExampleRelationshipSheet.Concept)]
        public string Concept { get; set; }

        [ImportColumn(TemplateConfig.ExampleRelationshipSheet.Relation)]
        public string ExampleLinkName { get; set; }

        
        /// Validate nhập khẩu
        
        /// <param name="lstExistExampleRel">Danh sách liên kết đã tồn tại</param>
        /// <param name="findConcept"></param>
        /// <param name="findExample"></param>
        /// <param name="findRelation"></param>
        
        public ValidateResultImport ValidateBusinessMater(List<ExampleRelationship> lstExistExampleRel,
            Concept findConcept, Example findExample, example_link findRelation)
        {
            var res = new ValidateResultImport
            {
                IsValid = true,
                Row = RowIndex,
                ListErrorMessage = new List<string>()
            };

            // Validate concept
            if (string.IsNullOrEmpty(Concept))
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.Required, "Concept"));
            }
            else if (findConcept == null)
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.NotExist, "Concept"));
            }

            // Validate example
            if (string.IsNullOrEmpty(ExampleHtml))
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.Required, "Example"));
            }
            else if (findExample == null)
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.NotExist, "Example"));
            }

            // Validate relation
            if (string.IsNullOrEmpty(ExampleLinkName))
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.Required, "Relation"));
            }
            else if (findRelation == null)
            {
                res.IsValid = false;
                res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.NotExist, "Relation"));
            }

            // Validate duplicate
            if(findConcept != null && findExample != null)
            {
                if (lstExistExampleRel.Any(x => x.ConceptId == findConcept.ConceptId && x.ExampleId == findExample.ExampleId))
                {
                    res.IsValid = false;
                    res.ListErrorMessage.Add(string.Format(ImportValidateErrorMessage.Duplicated, "Row"));
                }
            }

            return res;
        }
    }
}
