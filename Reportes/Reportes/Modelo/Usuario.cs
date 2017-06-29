using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reportes.Modelo
{
    [Table("admUsuarios")]
    class Usuario
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un usuario")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "Se requiere un password")]
        public string password { get; set; }
        [Required(ErrorMessage = "Se requiere ingrese el nombre")]
        public string nombre { get; set; }
        public Boolean estado { get; set; }

        public virtual Rol rol { get; set; }

        public Usuario()
        {
            this.estado = true;
            this.password = "4297f44b13955235245b2497399d7a93";
        }
    }
}
