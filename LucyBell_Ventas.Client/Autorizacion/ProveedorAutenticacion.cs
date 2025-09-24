using Azure.Core;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace LucyBell_Ventas.Client.Autorizacion
{
    public class ProveedorAutenticacion : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //await Task.Delay(5000);
            var anonimo = new ClaimsIdentity();
            var usuarioPipi = new ClaimsIdentity(
                new List<Claim> 
                { 
                    new Claim(ClaimTypes.Name, "Pipi"),
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim("DNI","45.407.028")
                },
                authenticationType:"ok"
                );

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonimo)));
        }
    }
}
