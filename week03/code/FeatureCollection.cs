public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public string? Type { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("features")]
    public List<Feature> Features { get; set; } = new List<Feature>();
}

public class Feature
{
    [System.Text.Json.Serialization.JsonPropertyName("type")]
    public string? Type { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("properties")]
    public Properties? Properties { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public string? Id { get; set; }
}

public class Properties
{
    [System.Text.Json.Serialization.JsonPropertyName("place")]
    public string? Place { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("mag")]
    public double? Mag { get; set; }
}