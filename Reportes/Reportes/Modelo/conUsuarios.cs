using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reportes.Modelo
{
    class conUsuarios
    {
        public static Usuario uAutentificado;
        public static List<Usuario> listar() {
            List<Usuario> lista;
            using (var ctx = new DataModel()) {
                lista = ctx.Usuarios.Include("rol").Include("rol.PermisosNegados").Where(c=>c.estado==true).OrderBy(c => c.nombre).ToList();
            }
            return lista;
        }
        public static Usuario obtener(int id) {
            Usuario usuario;
            using (var ctx = new DataModel()) {
                usuario = ctx.Usuarios.Include("rol").Include("rol.PermisosNegados").Where(c => c.id == id).FirstOrDefault();
            }
            return usuario;
        }
        public static List<Usuario> filtrarNombre(string nombre) {
            List<Usuario> lista;
            using (var ctx = new DataModel())
            {
                lista = ctx.Usuarios.Include("rol").Where(c => c.nombre.Contains(nombre)).OrderBy(c => c.nombre).ToList();
            }
            return lista;
        }

        public static void guardar(Usuario nUsuario) {
            using (var ctx = new DataModel()) {
                if (nUsuario.id > 0)
                {
                    ctx.Entry(nUsuario).State = System.Data.Entity.EntityState.Modified;
                }
                else {
                    ctx.Usuarios.Add(nUsuario);
                }
                ctx.SaveChanges();
            }
        }

        public static Rol buscarRol(int id) {
            using (var ctx = new DataModel()) {
                return ctx.Roles.Where(c => c.id == id).FirstOrDefault();
            }
        }

        public static Boolean existeMail(string mail) {
            Usuario usuario;
            using (var ctx = new DataModel()) {
                usuario = ctx.Usuarios.Where(c => c.usuario == mail).FirstOrDefault();
            }
            if (usuario != null)
                return true;
            else
                return false;
        }

        public static Boolean autentificar(string email,string password) {
            Usuario user;
            Boolean resul = false;
            using (var ctx=new DataModel()) {
                user = ctx.Usuarios.Include("rol").Include("rol.PermisosNegados").Include("rol.PermisosNegados.permiso").Where(c => c.usuario == email).FirstOrDefault();
                if (user != null) {
                    if (user.password == Tools.Seguridad.GetMD5(password)) {
                        uAutentificado= user;
                        resul = true;
                    }
                }
            }
            return resul;
        }

    }
}
