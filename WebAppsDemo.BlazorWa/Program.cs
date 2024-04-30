using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using WebAppsDemo.BlazorWa;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

////builder.Services.AddMicrosoftIdentityWebAppAuthentication(Configuration)
////    .EnableTokenAcquisitionToCallDownstreamApi(
////        Configuration.GetSection("TodoList").GetValue<string[]>("Scopes")
////    )
////    .AddInMemoryTokenCaches();

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
});

await builder.Build().RunAsync();
