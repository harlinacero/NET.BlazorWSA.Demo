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
    }
}
