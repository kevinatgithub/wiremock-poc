namespace wiremock_std.Helpers;
public class EmployeeHttpHelper: BaseHttpHelper
{
    public EmployeeHttpHelper(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("EmployeeService");
    }    
}
