using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Utils
{
    public static class PageUtils
    {
        public static void ValidateResult(NavigationManager navigationManager, IToastService toastService, string errorMessage, string pageLink, string successMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
            {
                navigationManager.NavigateTo(pageLink);
                toastService.ShowSuccess(successMessage);
            }
            else
            {
                toastService.ShowError(errorMessage);
            }
        }

        public static IEnumerable<int> GenerateRandomList(int limit)
        {
            List<int> randomNumbers = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < limit; i++)
            {
                randomNumbers.Add(rand.Next(100));
            }
            return randomNumbers;
        }
    }
}
