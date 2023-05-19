using Newtonsoft.Json;

namespace BlazorApp.Models
{
    public class Profile
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthdate")]
        public string Birthdate { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("profession")]
        public string Profession { get; set; }

        [JsonProperty("professionalDescription")]
        public string ProfessionalDescription { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("educations")]
        public List<Education> Educations { get; set; }

        [JsonProperty("experiences")]
        public List<Experience> Experiences { get; set; }

        [JsonProperty("skills")]
        public List<Skill> Skills { get; set; }

        public Profile()
        {
            Educations = new List<Education>();
            Skills = new List<Skill>();
            Experiences = new List<Experience>();
        }


    }
}

