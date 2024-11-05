using Microsoft.EntityFrameworkCore;
using LucyBell_Ventas.BD.Data;
using LucyBell_Ventas.BD.Data.Entity;

namespace LucyBell_Ventas.Server.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly Context context;

        public CategoriaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
