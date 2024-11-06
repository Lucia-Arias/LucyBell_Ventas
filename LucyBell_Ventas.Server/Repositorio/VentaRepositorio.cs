using LucyBell_Ventas.BD.Data.Entity;
using LucyBell_Ventas.BD.Data;

namespace LucyBell_Ventas.Server.Repositorio
{
    public class VentaRepositorio : Repositorio<Venta>, IVentaRepositorio
    {
        private readonly Context context;
        
        public VentaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
