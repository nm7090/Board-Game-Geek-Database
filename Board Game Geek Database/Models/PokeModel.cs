using System.Text.Json.Serialization;

namespace Board_Game_Geek_Database.Models
{
    public class PokeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }

        public List<AbilityDto> Abilities { get; set; } = new List<AbilityDto>();
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
        public List<AbilityDto> Abilities { get; set; } = new List<AbilityDto>();
    }

    public class AbilityDto
    {
        public Boolean is_hidden { get; set; }
        public int slot { get; set; }
        public AbilityNameDto? ability { get; set; }
    }

    public class AbilityNameDto
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }
}
