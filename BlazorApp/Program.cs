using BlazorApp;
using BlazorApp.Charts;
using BlazorApp.Models;
using BlazorApp.Services;
using BlazorApp.Services.Contracts;
using Blazored.Toast;
using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.PieChart;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;




var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IRepository<Product>, ProductService>();
builder.Services.AddScoped<IRepository<Category>, CategoryService>();
builder.Services.AddScoped<IRepository<User>, UsersService>();
builder.Services.AddScoped<IFilterService<Product>, ProductsFilterService>();
builder.Services.AddScoped<IAboutService, AboutService>();

builder.Services.AddScoped<IChart<PieConfig>, PieChart>();
builder.Services.AddScoped<IChart<BarConfig>, VerticalChart>();
// builder.Services.AddScoped<IChart<BarConfig>, HorizontalChart>();


builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
