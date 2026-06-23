using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BackOffice.MVC.Services;

public interface IApiClient
{
    Task<T?> GetAsync<T>(string endpoint);
    Task<T?> PostAsync<T>(string endpoint, object data);
    Task<T?> PutAsync<T>(string endpoint, object data);
    Task<bool> DeleteAsync(string endpoint);
    void SetAuthToken(string token);
    string? GetAuthToken();
}

public class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string TokenKey = "JwtToken";

    public ApiClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public void SetAuthToken(string token)
    {
        _httpContextAccessor.HttpContext?.Session.SetString(TokenKey, token);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public string? GetAuthToken()
    {
        return _httpContextAccessor.HttpContext?.Session.GetString(TokenKey);
    }

    private void EnsureAuthToken()
    {
        var token = GetAuthToken();
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        EnsureAuthToken();
        var response = await _httpClient.GetAsync(endpoint);
        
        if (!response.IsSuccessStatusCode)
            return default;

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content);
    }

    public async Task<T?> PostAsync<T>(string endpoint, object data)
    {
        EnsureAuthToken();
        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync(endpoint, content);
        
        if (!response.IsSuccessStatusCode)
            return default;

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent);
    }

    public async Task<T?> PutAsync<T>(string endpoint, object data)
    {
        EnsureAuthToken();
        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PutAsync(endpoint, content);
        
        if (!response.IsSuccessStatusCode)
            return default;

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent);
    }

    public async Task<bool> DeleteAsync(string endpoint)
    {
        EnsureAuthToken();
        var response = await _httpClient.DeleteAsync(endpoint);
        return response.IsSuccessStatusCode;
    }
}

// Made with Bob
