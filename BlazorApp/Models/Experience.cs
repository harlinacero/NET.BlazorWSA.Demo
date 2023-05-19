using Newtonsoft.Json;

namespace BlazorApp.Models
{
    public class Experience
    {
        private string totalTemp;
        private string workingDates;

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("finish")]
        public string Finish { get; set; }
        public string TotalTemp
        {
            get { return $"{((string.IsNullOrEmpty(Finish) ? DateTime.Now : DateTime.Parse(Finish)) - DateTime.Parse(Start)).Days / 365} years"; }
            set { totalTemp = value; }
        }

        public string WorkingDates { 
            get => $"{DateTime.Parse(Start):MMMM yyyy} - { (string.IsNullOrEmpty(Finish) ? "Actualmente" : DateTime.Parse(Finish).ToString("MMMM yyyy"))}"; 
            set => workingDates = value; 
        }

    }
}

