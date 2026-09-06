using System.Text.Json.Serialization;

namespace Board_Game_Geek_Database.Models
{
    public class PokeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }

        public List<Dictionary<string, object>> Abilities { get; set; } = new List<Dictionary<string, object>>();
    }

    public class PokeModelDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("order")]
        public int Order { get; set; }
        [JsonPropertyName("weight")]
        public int Weight { get; set; }
        [JsonPropertyName("abilities")]
        public List<Dictionary<string, object>> Abilities { get; set; } = new List<Dictionary<string, object>>();
    }
}
