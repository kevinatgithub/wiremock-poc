using System.Net.Http;

namespace wiremock_std.Helpers;

public abstract class BaseHttpHelper
{
    public HttpClient _httpClient;

    protected BaseHttpHelper()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GetAsync(string url)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        throw new Exception($"HTTP Error: {response.StatusCode}");
    }

    public async Task<string> PostAsync(string url, string body)
    {
        StringContent content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        throw new Exception($"HTTP Error: {response.StatusCode}");
    }

    public async Task<string> PutAsync(string url, string body)
    {
        StringContent content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PutAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        throw new Exception($"HTTP Error: {response.StatusCode}");
    }

    public async Task<string> DeleteAsync(string url)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        throw new Exception($"HTTP Error: {response.StatusCode}");
    }
}
