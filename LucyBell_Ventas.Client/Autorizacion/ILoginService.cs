using LucyBell_Ventas.Shared.DTO;

namespace LucyBell_Ventas.Client.Autorizacion
{
    public interface ILoginService
    {
        Task Login(UserTokenDTO tokenDTO);
        Task Logout();
    }
}
