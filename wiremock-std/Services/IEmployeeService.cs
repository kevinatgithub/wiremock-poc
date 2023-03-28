using wiremock_std.Models;

namespace wiremock_std.Services;

public interface IEmployeeService
{
    public Task<Employee> GetByIdAsync(int id);
}
