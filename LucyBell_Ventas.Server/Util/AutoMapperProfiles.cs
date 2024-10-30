using AutoMapper;
using LucyBell_Ventas.BD.Data.Entity;
using LucyBell_Ventas.Shared.DTO;

namespace LucyBell_Ventas.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearProductoDTO, Producto>();
        }
    }
}
