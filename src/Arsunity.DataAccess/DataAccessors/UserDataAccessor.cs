using System.Collections.Generic;
using Arsunity.Interfaces.DataAccess.Interfaces;
using Arsunity.Interfaces.DataAccess.Models;
using Arsunity.DataAccess.DataContexts;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Arsunity.DataAccess.DataAccessors
{
    internal class UserDataAccessor : IUserDataAccessor
    {
        private readonly PrototypeDbContext Context;

        public UserDataAccessor(PrototypeDbContext context)
        {
            Context = context;
        }

        public bool CheckUsers()
        {
            return Context.Users.Any();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Context.Users.AsNoTracking();
        }

        public User GetUserById(Guid id)
        {
            return Context.Users.Where(x => x.Id == id).AsNoTracking().Single();
        }

        public void SaveUser(User user)
        {
            var existUser = Context.Users.Where(x => x.Id == user.Id).SingleOrDefault();

            if (existUser == null)
            {
                Context.Users.Add(user);
            }
            else
            {
                existUser.Login = user.Login;
                existUser.Password = user.Password;
            }
            Context.SaveChanges();
        }

        public void AddUsers(IEnumerable<User> users)
        {
            Context.Users.AddRange(users);
            Context.SaveChanges();
        }
    }
}
