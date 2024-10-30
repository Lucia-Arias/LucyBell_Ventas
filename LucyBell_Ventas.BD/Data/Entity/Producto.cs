using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LucyBell_Ventas.BD.Data.Entity
{
    public class Producto : EntityBase
    {
       [Required(ErrorMessage = "El nombre es obligatorio.")]
       [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
       public string Nombre { get; set; }

       [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser un número no negativo.")]
       public int Stock { get; set; }

       [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
       public decimal Precio { get; set; }
    }
}

