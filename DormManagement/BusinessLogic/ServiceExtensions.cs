using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace BusinessLogic
{
    public static class ServicesExtensions
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddTransient<IDormRepository, DormRepository>();
        }
    }
}
