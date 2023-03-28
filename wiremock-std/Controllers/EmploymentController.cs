using Microsoft.AspNetCore.Mvc;
using wiremock_std.Services;
using wiremock_std.WireMocks;

namespace wiremock_std.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmploymentController : ControllerBase
{
    private readonly IEmploymentService _employmentService;

    public EmploymentController(IEmploymentService employmentService)
    {
        _employmentService = employmentService ?? throw new ArgumentNullException(nameof(employmentService));
    }

    [WireEmploymentFilter]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmploymentById(int id)
    {
        var employment = await _employmentService.GetByIdAsync(id);
        return Ok(employment);
    }
}
