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
        Console.WriteLine("GetMyActivitiesAsync wurde aufgerufen.");

        if (!_userSession.IsLoggedIn)
        {
            Console.WriteLine("Fehler: Nutzer ist nicht eingeloggt.");
            return null;
        }

        // Token für DIESE eine Anfrage setzen
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _userSession.AccessToken);

        var requestUrl = "https://www.strava.com/api/v3/athlete/activities";
        Console.WriteLine($"Sende Anfrage an: {requestUrl}");

        try
        {
            var activities = await _httpClient.GetFromJsonAsync<List<StravaActivity>>(requestUrl);
            Console.WriteLine($"Erfolg: {activities?.Count ?? 0} Aktivitäten gefunden.");
            return activities;
        }
        catch (HttpRequestException ex)
        {
            // Gib den echten Fehler aus, anstatt ihn zu verschlucken!
            Console.WriteLine($"API-Fehler! Status: {ex.StatusCode}, Nachricht: {ex.Message}");
            return null;
        }
    }
}