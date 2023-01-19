using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using OFM.SellerPortal;
using OFM.SellerPortal.Services;
using OFM.SellerPortal.Services.Interfaces;
using OFM.SellerPortal.ViewModels;
using OFM.SellerPortal.ViewModels.Interfaces;
using System.Globalization;
using System.Security.Claims;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddSingleton<ILanguageSelectorViewModel, LanguageSelectorViewModel>();
builder.Services.AddScoped<ILoginViewModel, LoginViewModel>();

builder.Services.AddLocalization();
var jsInterop = builder.Build().Services.GetRequiredService<IJSRuntime>();
var appLanguage = await jsInterop.InvokeAsync<string>("appCulture.get");
if (appLanguage != null)
{
    CultureInfo cultureInfo = new(appLanguage);
    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
}

builder.Services.AddBlazoredLocalStorageAsSingleton();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore(options =>
{ 
    options.AddPolicy("CanAdd", policy => policy.RequireClaim("canAdd", true.ToString()));
    options.AddPolicy("CanEdit", policy => policy.RequireClaim("canUpdate", true.ToString()));
});
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
