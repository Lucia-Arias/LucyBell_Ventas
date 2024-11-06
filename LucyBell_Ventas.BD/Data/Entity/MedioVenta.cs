using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucyBell_Ventas.BD.Data.Entity
{
    public class MedioVenta : EntityBase
    {
        [Required(ErrorMessage = "El nombre del medio de venta es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del medio de venta no puede exceder los 100 caracteres.")]
        public string Nombre_MedioVenta { get; set; }
    }
}
