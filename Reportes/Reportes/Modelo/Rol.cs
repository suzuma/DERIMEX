using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Reportes.Modelo
{
    [Table("admRoles")]
    class Rol
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Debe ingresar el rol")]
        public string nombre { get; set; }

        public ICollection<Usuario> usuarios { get; set; }
        public ICollection<PermisoNegadoRol> PermisosNegados { get; set; }



    }
}
