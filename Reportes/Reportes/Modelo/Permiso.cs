using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reportes.Modelo
{
    [Table("admPermisos")]
    class Permiso
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Se requiere ingrese el nombre del permiso")]
        public string nombre { get; set; }

        public ICollection<PermisoNegadoRol> PermisoNegados { get; set; }
    }
}
