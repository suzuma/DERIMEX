namespace Reportes.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Reportes.Modelo;
    internal sealed class Configuration : DbMigrationsConfiguration<Reportes.Modelo.DataModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient",
               new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(Reportes.Modelo.DataModel context)
        {
            context.Roles.AddOrUpdate(
                p => p.id,
                new Rol
                {
                    id = 1,
                    nombre = "Administrador"
                },
                new Rol
                {
                    id = 2,
                    nombre = "Usuario"
                }
                );

            context.Usuarios.AddOrUpdate(
                p => p.usuario,
                new Usuario
                {
                    id = 1,
                    usuario = "Admin",
                    password = "4297f44b13955235245b2497399d7a93",
                    nombre = "Administrador General",
                    estado = true,
                    rol = new Rol { id = 1, nombre = "Usuario" }
                }
                );
            context.Permisos.AddOrUpdate(
                p => p.nombre,
                new Permiso
                {
                    id = 1,
                    nombre = "SINCRONIZAR"
                },
                new Permiso
                {
                    id = 2,
                    nombre = "ENVIAR A MEMORIA"
                },
                new Permiso
                {
                    id = 3,
                    nombre = "EXPORTAR A EXCEL"
                },
                new Permiso
                {
                    id = 4,
                    nombre = "EXPORTAR A HTML"
                },
                new Permiso
                {
                    id = 5,
                    nombre = "EXPORTAR A PDF"
                },
                new Permiso
                {
                    id = 6,
                    nombre = "ENVIAR REPORTE POR EMAIL"
                },
                new Permiso
                {
                    id = 7,
                    nombre = "CONFIGURAR SISTEMA"
                },
                new Permiso
                {
                    id = 8,
                    nombre = "ADMINISTRAR USUARIOS"
                }
                );
        }
    }
}
