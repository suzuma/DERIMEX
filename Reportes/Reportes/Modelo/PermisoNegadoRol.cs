using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reportes.Modelo
{
    [Table("admPermisosNegadosRol")]
    class PermisoNegadoRol
    {
        [Key]
        public int id { get; set; }

        public virtual Permiso permiso { get; set; }
        public virtual Rol rol { get; set; }

    }
}
