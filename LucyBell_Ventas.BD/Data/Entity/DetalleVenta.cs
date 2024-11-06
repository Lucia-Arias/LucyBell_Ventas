using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucyBell_Ventas.BD.Data.Entity
{
    public class DetalleVenta : EntityBase
    {
        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El subtotal es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El subtotal debe ser mayor que cero.")]
        public int Subtotal { get; set; }

        //Foreign Key
        
        [Required(ErrorMessage = "La Venta es obligatoria.")]
        public int VentaId { get; set; }

        public Venta Venta { get; set; }
        
        [Required(ErrorMessage = "El Producto es obligatorio.")]
        public int ProductoId { get; set; }

        public Producto Producto { get; set; }
    }
}
