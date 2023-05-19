using Newtonsoft.Json;

namespace BlazorApp.Models
{
    public class Education
    {
        [JsonProperty("institute")]
        public string Institute { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("finish")]
        public string Finish { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string? Image { get; set; }
    }
}

