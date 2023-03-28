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
        services.AddHttpClient("EmploymentService", client =>
        {
            client.BaseAddress = new Uri("http://localhost:1002");
        });
        services.AddSingleton<EmployeeHttpHelper>();
        services.AddSingleton<EmploymentHttpHelper>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEmploymentService, EmploymentService>();
    }
}
