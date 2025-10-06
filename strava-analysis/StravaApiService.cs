using System.Net.Http.Json;
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
    
    // Activities of a Strava Athlete
    public async Task<List<StravaActivity>> GetStravaActivitiesAsync()
    {
        var requestUrl = "https://www.strava.com/api/v3/athlete/activities";

        var activities = await _httpClient.GetFromJsonAsync<List<StravaActivity>>(requestUrl);
        
        return activities;
    }
}