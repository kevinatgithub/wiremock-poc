using Microsoft.AspNetCore.Mvc.Filters;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using wiremock_std.Models;

namespace wiremock_std.WireMocks;

public class WireEmploymentFilterAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.HttpContext.Request.RouteValues.TryGetValue("id", out var id);
        var employment = new Employment
        {
            Id = int.Parse(id.ToString()),
            Name = "Employment 1",
            Description = "Desc 1",
            Salary = 112000m
        };

        var wireMock = WireMockServer.Start(1002);
        wireMock.Given(Request.Create()
            .WithPath($"/api/Employment/{id}")
        .UsingGet())
            .RespondWith(Response.Create()
            .WithStatusCode(200)
            .WithBodyAsJson(employment));

        await next();
    }
}
