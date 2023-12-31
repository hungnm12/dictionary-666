﻿using AutoMapper;
using H2KT.Core.Models.ServerObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2KT.Core.Utils
{
    public interface INhom2ServiceCollection
    {
        public IConfigUtil ConfigUtil { get; set; }
        public IAuthUtil AuthUtil { get; set; }
        public IDistributedCacheUtil CacheUtil { get; set; }
        public IMapper Mapper { get; set; }
        public ILogUtil LogUtil { get; set; }

        public void HandleControllerException(IServiceResult serviceResult, Exception ex);
    }
}
