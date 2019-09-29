namespace Users.UI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    using Users.UI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {       
            InicializarIdentity(context);
        }

        /// <summary>
        /// Iniciamos la base de datos si no tenemos usuarios creados:        /// 
        /// Creamos el usuario antoniocasas7@gmail.com password: IoT@123 por defecto para la aplicación.
        /// </summary>
        /// <param name="context">Contexto de la BBDD</param>
        public static void InicializarIdentity(ApplicationDbContext context)
        {

            //if (!context.Users.Any())
            //{
            //    var passwordHash = new PasswordHasher();
            //    string password = passwordHash.HashPassword("IoT@123");
            //    context.Users.AddOrUpdate(u => u.UserName,
            //    new ApplicationUser
            //    {
            //        Email = "antoniocasas7@gmail.com",
            //        EmailConfirmed = true,
            //        UserName = "antoniocasas7@gmail.com",
            //        PasswordHash = password,
            //        SecurityStamp = Guid.NewGuid().ToString()
            //    }); ;
            //    context.SaveChanges();
            //}

            //if (!context.User.Any())
            //{
            //    List<User> usuariosIniciales = new List<User>
            //        {
            //            new User { Id = 1, Name = "Juan Garcia", CreateDate = DateTime.Now.Date, UpdateDate = DateTime.Now.Date},
            //            new User{ Id = 2, Name = "Carmen Lara", CreateDate =  DateTime.Now.Date, UpdateDate = DateTime.Now.Date },
            //        };

            //    // Creo los Usuarios iniciales para la entidad Users
            //    context.User.AddRange(usuariosIniciales);
            //    context.SaveChanges();
            //}
        }
    }
}
