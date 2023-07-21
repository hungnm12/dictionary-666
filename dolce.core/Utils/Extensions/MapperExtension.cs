using Microsoft.Extensions.DependencyInjection;
using H2KT.Core.Models;

namespace H2KT.Core.Extensions
{
    
    /// Extension cho auto mapper
    
    public static class MapperExtension
    {
        public static void UseAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
