using Arsunity.Interfaces.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace Arsunity.Interfaces.DataAccess.Interfaces
{
    public interface IUserDataAccessor
    {
        bool CheckUsers();
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid id);
        void SaveUser(User user);
        void AddUsers(IEnumerable<User> users);
    }
}
