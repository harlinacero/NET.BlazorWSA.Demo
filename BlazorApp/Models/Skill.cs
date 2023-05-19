using Newtonsoft.Json;

namespace BlazorApp.Models
{
    public class Skill
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }

}