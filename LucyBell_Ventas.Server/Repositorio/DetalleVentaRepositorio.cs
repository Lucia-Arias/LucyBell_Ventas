using LucyBell_Ventas.BD.Data;
using LucyBell_Ventas.BD.Data.Entity;

namespace LucyBell_Ventas.Server.Repositorio
{
    public class DetalleVentaRepositorio : Repositorio<DetalleVenta>, IDetalleVentaRepositorio
    {
        private readonly Context context;
        public DetalleVentaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
