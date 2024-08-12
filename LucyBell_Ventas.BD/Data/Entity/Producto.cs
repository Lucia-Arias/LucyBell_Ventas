using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucyBell_Ventas.BD.Data.Entity
{
    public class Producto : EntityBase
    {
        public string Nombre { get; set; }

        public int Stock { get; set; }

        public decimal Precio { get; set; }
    }
}
