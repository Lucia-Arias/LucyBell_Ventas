using LucyBell_Ventas.BD.Data;
using LucyBell_Ventas.BD.Data.Entity;

namespace LucyBell_Ventas.Server.Repositorio
{
    public class MedioVentaRepositorio : Repositorio<MedioVenta>, IMedioVentaRepositorio
    {
        private readonly Context context;
        public MedioVentaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
