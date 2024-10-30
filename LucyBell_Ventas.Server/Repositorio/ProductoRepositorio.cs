using LucyBell_Ventas.BD.Data;
using LucyBell_Ventas.BD.Data.Entity;

namespace LucyBell_Ventas.Server.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        public ProductoRepositorio(Context contex) : base(contex)
        {
            
        }


    }
}
