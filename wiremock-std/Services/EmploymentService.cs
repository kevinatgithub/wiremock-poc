using wiremock_std.Helpers;
using wiremock_std.Models;

namespace wiremock_std.Services;

public class EmploymentService : IEmploymentService
{
    private readonly EmploymentHttpHelper _httpHelper;

    public EmploymentService(EmploymentHttpHelper httpHelper)
    {
        _httpHelper = httpHelper ?? throw new ArgumentNullException(nameof(httpHelper));
    }

    public async Task<Employment> GetByIdAsync(int id)
    {
        var employment = await _httpHelper.GetAsync($"/api/Employment/{id}");
        if (employment == null)
        {
            return null;
        }
        return CommonHelpers.ToObject<Employment>(employment);
    }
}
