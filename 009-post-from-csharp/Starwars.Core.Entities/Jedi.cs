using System.Text.Json.Serialization;

namespace Starwars.Core.Entities
{
    public class Jedi
    {
        [JsonPropertyName("jediId")]
        public int JediId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public Jedi()
        {

        }

        public Jedi(int id, string name)
        {
            JediId = id;
            Name = name;
        }
    }
}