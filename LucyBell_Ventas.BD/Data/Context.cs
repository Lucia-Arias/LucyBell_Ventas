using LucyBell_Ventas.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucyBell_Ventas.BD.Data
{
    public class Context : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<MedioVenta> MedioVenta { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(p => p.Producto)
                .WithMany()
                .HasForeignKey(p => p.ProductoId);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(p => p.Venta)
                .WithMany()
                .HasForeignKey(p => p.VentaId);

            modelBuilder.Entity<Venta>()
                .HasOne(p => p.MedioVenta)
                .WithMany()
                .HasForeignKey(p => p.MedioVentaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}