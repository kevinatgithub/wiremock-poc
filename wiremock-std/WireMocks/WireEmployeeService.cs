using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using wiremock_std.Models;

namespace wiremock_std.WireMocks;

public static class WireEmployeeService
{
    public static WireMockServer Start()
    {
        var wireMock = WireMockServer.Start(1001);
        return wireMock;
    }

    public static void GetEmployee(this WireMockServer wireMock, int id, Employee employee)
    {
        wireMock.Given(Request.Create()
            .WithPath($"/api/Employees/{id}")
            .UsingGet())
            .RespondWith(Response.Create()
            .WithStatusCode(200)
            .WithBodyAsJson(employee));
    }
}
