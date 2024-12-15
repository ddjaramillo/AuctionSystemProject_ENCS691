using BlazorAuctionSystemProject;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


// Register HttpClient with a base address
builder.Services.AddHttpClient("BlazorAuctionSystemProject.ServerAPI", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
// Supply HttpClient instances that include access tokens
/*builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("BlazorAuctionSystemProject.ServerAPI"));*/

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://lockitservices.onmicrosoft.com/ac0fcd32-b5e3-4697-a737-85df0a5d3ae1/Auction.ReadWrite");
});

await builder.Build().RunAsync();
