using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace strava_analysis.Services;

public class StravaApiService
{
    private readonly HttpClient _httpClient;
    private readonly UserSession _userSession;
    
    public StravaApiService(HttpClient httpClient, UserSession userSession)
    {
        _httpClient = httpClient;
        _userSession = userSession;
    }
    
    // Strava Access-Token for OAtuh2
    public void SetAccessToken(string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", accessToken);
    }
    
    // Activities of a Strava Athlete
    public async Task<List<StravaActivity>?> GetStravaActivitiesAsync()
    {
        var requestUrl = "https://www.strava.com/api/v3/athlete/activities";

        if (!_userSession.IsLoggedIn)
        {
            return null;
        }
        
        _httpClient.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", _userSession.AccessToken);

        try
        {
            var activities = await _httpClient.GetFromJsonAsync<List<StravaActivity>>(requestUrl);
            return activities;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"API Request failed: {ex.Message}");
            return null;
        }
    }
}