using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucyBell_Ventas.BD.Data
{
    public class EntityBase : IEntityBase
    {
       [Key]
        public int Id { get; set; }
    }
}
