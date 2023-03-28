using wiremock_std.Helpers;
using wiremock_std.Services;

namespace wiremock_std.Extensions;

public static class ProgramExtensions
{
    public static void AddEmployeeServiceHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("EmployeeService", client =>
        {
            client.BaseAddress = new Uri("http://localhost:1001");
        });
        services.AddSingleton<EmployeeHttpHelper>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
    }
}
