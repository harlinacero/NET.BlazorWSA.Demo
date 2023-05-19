using BlazorApp.Models;

namespace BlazorApp.Services.Contracts
{
    public interface IAboutService
    {
        /// <summary>
        /// Get data of profile in about
        /// </summary>
        /// <returns></returns>
       Task<Profile> GetPersonalData();
    }
}