using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GNUCannabis;
using GNUCannabis.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5024/api/") });

builder.Services.AddScoped<GrowerService>();
builder.Services.AddScoped<PlantService>();
builder.Services.AddScoped<CropService>();

await builder.Build().RunAsync();
