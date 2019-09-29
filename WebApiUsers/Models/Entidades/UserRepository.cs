using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace WebApiUsers.Models.Entidades
{
    public class UserRepository : IDisposable, IUserRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public void Add(User usuario)
        {           
            db.User.Add(usuario);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = db.User.Find(id);
            if (user != null)
            {
                db.User.Remove(user);
                db.SaveChanges();
            }
        }


        public void Edit(User usuario)
        {
            User user = db.User.Find(usuario.Id);
            if (user != null)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }

        }

        public List<User> GetAll()
        {
            return db.User.ToList();
        }

        public User GetById(int id)
        {
            return db.User.FirstOrDefault(p => p.Id == id);
        }


        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Edit(int id)
        {
            throw new NotImplementedException();
        }
    }
}