using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucyBell_Ventas.BD.Data.Entity
{
    //public enum MedioVenta
    //{
    //    Feria,
    //    WhatsApp,
    //    Facebook,
    //    Instagram,
    //    Contacto,
    //    TiendaWeb
    //}

    public class Venta : EntityBase
    {
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El total es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El total debe ser mayor que cero.")]
        public int Total { get; set; }

        //Foreign Key
        [Required(ErrorMessage = "El medio de venta es obligatorio.")]
        public int MedioVentaId { get; set; }

        public MedioVenta MedioVenta { get; set; }
    }
}
