using H2KT.Core.Enums;
using H2KT.Core.Models.Entity;
using System;
using System.Collections.Generic;

namespace H2KT.Core.Models.ServerObject
{
    
    /// Dữ liệu config: concept link, example link, tone, mode, register, nuance, dialect
    
    public class UserConfigData
    {
        public List<concept_link> ListConceptLink { get; set; }
        public List<example_link> ListExampleLink { get; set; }
        public List<tone> ListTone { get; set; }
        public List<mode> ListMode { get; set; }
        public List<register> ListRegister { get; set; }
        public List<nuance> ListNuance { get; set; }
        public List<dialect> ListDialect { get; set; }
    }
}
