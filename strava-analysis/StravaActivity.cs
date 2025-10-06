using System.Text.Json.Serialization;

public class StravaActivity
{
    [JsonPropertyName("name")]
    public string Title { get; set; }

    [JsonPropertyName("distance")]
    public double DistanceInMeters { get; set; }

    [JsonPropertyName("moving_time")]
    public int MovingTimeInSeconds { get; set; }

    [JsonPropertyName("total_elevation_gain")]
    public double ElevationGainInMeters { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("start_date_local")]
    public DateTime StartDateLocal { get; set; }

    [JsonPropertyName("kudos_count")]
    public int KudosCount { get; set; }
}