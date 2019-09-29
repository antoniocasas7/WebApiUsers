using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiUsers.Models;
using WebApiUsers.Models.Entidades;

namespace WebApiUsers.Controllers
{

    /// <summary xml:lang="es-ES">
    ///     Controlador encargado de realizar las operacion de la entidad User.
    /// </summary>

    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private IUserRepository _usersRepository;

        public UserController(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        // GET: localhost:64208/api/User
        /// <summary>
        ///     Obtiene todos los Usuarios
        /// </summary>   
        /// <returns>Resultado de la operacion de tipo Lista de Usuarios</returns>
        [Route("GetAll")]
        [HttpGet]
        [ResponseType(typeof(List<User>))]
        public List<User> GetAllUser()
        {
            // return db.User;
            return _usersRepository.GetAll();
        }

        // GET: localhost:64208/api/User/5

        ///  <summary>
        ///      Obtiene el Usuario con el Id = id
        /// </summary>
        /// <param name="id">Id del Usuario</param>
        /// <returns>Resultado de la operacion de tipo User</returns>
        [Route("GetById")]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUserById(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: localhost:64208/api/User/5

        ///  <summary>
        ///      Edita un usuario
        /// </summary>
        /// <param name="id">Id del Usuario</param>
        /// <param name="user">El Usuario a editar</param>
        /// <returns>Resultado de la operacion de tipo IHttpActionResult</returns>
        [Route("Edit")]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult EditUser(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest(ModelState);
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }        
            return Ok(user);
        }

        // POST: localhost:64208/api/User
        ///  <summary>
        ///      Añade un Usuario 
        /// </summary>
        /// <param name="user">El Usuario a añadir </param>
        /// <returns>Resultado de la operacion de tipo User</returns>
        [Route("Add")]
        [ResponseType(typeof(User))]
        public IHttpActionResult AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User.Add(user);
            db.SaveChanges();

            return Ok(user);
        }

        // POST: localhost:64208/api/User/5
        ///  <summary>
        ///      Obtiene el Usuario con el Id = id
        /// </summary>
        /// <param name="id">Id del Usuario</param>
        /// <returns>Resultado de la operacion de tipo User</returns>
        [Route("Delete")]
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.User.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.User.Count(e => e.Id == id) > 0;
        }
    }
}