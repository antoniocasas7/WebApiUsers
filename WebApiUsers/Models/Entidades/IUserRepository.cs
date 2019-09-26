using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiUsers.Models.Entidades
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User GetById(int id);

        void Add(User usuario);

        void Edit(User usuario);

        void Delete(int id);

    }
}