using System.Collections.Generic;
using Arsunity.Interfaces.DataAccess.Interfaces;
using Arsunity.Interfaces.DataAccess.Models;
using Arsunity.DataAccess.DataContexts;

namespace Arsunity.DataAccess.DataAccessors
{
    internal class UserDataAccessor : IUserDataAccessor
    {
        private readonly PrototypeDbContext Context;

        public UserDataAccessor(PrototypeDbContext context)
        {
            Context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Context.Users;
        }
    }
}
