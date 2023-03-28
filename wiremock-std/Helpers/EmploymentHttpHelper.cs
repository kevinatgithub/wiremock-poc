namespace wiremock_std.Helpers;

public class EmploymentHttpHelper : BaseHttpHelper
{
    public EmploymentHttpHelper(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("EmploymentService");
    }
}
