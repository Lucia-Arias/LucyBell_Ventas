using LucyBell_Ventas.Client;
using LucyBell_Ventas.Client.Autorizacion;
using LucyBell_Ventas.Client.Servicios;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IHttpServicio, HttpServicio>();

builder.Services.AddScoped<ProveedorAutenticacionJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacionJWT>(proveedor =>
    proveedor.GetRequiredService<ProveedorAutenticacionJWT>());
builder.Services.AddScoped<ILoginService, ProveedorAutenticacionJWT>(proveedor =>
    proveedor.GetRequiredService<ProveedorAutenticacionJWT>());

await builder.Build().RunAsync();
