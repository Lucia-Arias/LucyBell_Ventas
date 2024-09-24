using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LucyBell_Ventas.BD.Data.Entity;

namespace LucyBell_Ventas.BD.Data
{
    public class Context : DbContext
    {
        public DbSet<Producto> productos { get;set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ejemplo de configuración de precisión y escala para decimal
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasPrecision(18, 2);

            // Puedes agregar más configuraciones aquí según sea necesario

            base.OnModelCreating(modelBuilder);
        }
    }
}
