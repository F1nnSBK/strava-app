using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace strava_analysis.Services;

public class StravaApiService
{
    private readonly HttpClient _httpClient;
    
    public StravaApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
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