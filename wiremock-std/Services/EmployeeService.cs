using wiremock_std.Helpers;
using wiremock_std.Models;

namespace wiremock_std.Services;

public class EmployeeService : IEmployeeService
{
    private readonly EmployeeHttpHelper _httpHelper;

    public EmployeeService(EmployeeHttpHelper httpHelper)
    {
        _httpHelper = httpHelper ?? throw new ArgumentNullException(nameof(httpHelper));
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        var employeeStr = await _httpHelper.GetAsync($"api/Employees/{id}");
        if (employeeStr == null)
        {
            return null;
        }
        return CommonHelpers.ToObject<Employee>(employeeStr);
    }
}
