using H2KT.Core.Constants;
using H2KT.Core.Enums;
using H2KT.Core.Interfaces.Repository;
using H2KT.Core.Interfaces.Service;
using H2KT.Core.Models.DTO;
using H2KT.Core.Models.ServerObject;
using H2KT.Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Services
{
    
    /// Serivce base
    
    public class BaseService
    {
        protected INhom2ServiceCollection ServiceCollection;


        public BaseService(INhom2ServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }
    }


}
