using wiremock_std.Models;

namespace wiremock_std.Services;

public interface IEmploymentService
{
    public Task<Employment> GetByIdAsync(int id);
}
