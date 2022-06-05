using System.Text.Json.Serialization;

namespace Starwars.Core.Entities
{
    public class Jedi
    {
        [JsonPropertyName("jediId")]
        public int JediId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}