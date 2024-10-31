using LucyBell_Ventas.BD.Data;
using LucyBell_Ventas.BD.Data.Entity;

namespace LucyBell_Ventas.Server.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly Context context;
        public ProductoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }


    }
}
