using Microsoft.AspNetCore.Mvc;
using wiremock_std.Models;
using wiremock_std.Services;
using wiremock_std.WireMocks;

namespace wiremock_std.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var emp = new Employee
        {
            Id = id,
            Name = "Test",
            Position = "Test12"
        };
        WireEmployeeService.Start().GetEmployee(id, emp);
        var employee = await _employeeService.GetByIdAsync(id);
        return Ok(employee);
    }
}
