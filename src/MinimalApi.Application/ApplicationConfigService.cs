using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MinimalApi.Application;
public static class ApplicationConfigService
{
    public static void ApplicationServicesRegistration(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
