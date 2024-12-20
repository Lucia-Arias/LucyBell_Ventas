﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucyBell_Ventas.BD.Data.Entity
{
    public class Categoria : EntityBase
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        public string Nombre_Cat { get; set; }
    }
}
