namespace strava_analysis.Services;

public class UserSession
{
    public string? AccessToken { get; private set; }
    public bool IsLoggedIn => !string.IsNullOrEmpty(AccessToken);

    public void SetToken(string accessToken)
    {
        AccessToken = accessToken;
    }
}