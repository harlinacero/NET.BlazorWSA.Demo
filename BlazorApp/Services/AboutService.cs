using BlazorApp.Models;
using BlazorApp.Services.Contracts;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class AboutService : ServiceBase, IAboutService
    {

        public AboutService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Profile> GetPersonalData()
        {
            try
            {
                //var wwwrootPath = _env.ContentRootPath;
                //var filePath = Path.Combine("wwwroot", "data", "aboutme.json");
                //var filePath = Path.Combine("~/wwwroot", "data", "aboutme.json");

                //if (!File.Exists(filePath))
                //{
                //    throw new FileLoadException($"El archivo no fue encontrado {filePath}");
                //}

                var filePath = await _httpClient.GetFromJsonAsync<string>("data/aboutme.json");

                using var content = new StreamReader(filePath);
                var jsonString = await content.ReadToEndAsync();
                return JsonConvert.DeserializeObject<Profile>(jsonString);
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException(ex.Message);
            }

        }
    }
}
