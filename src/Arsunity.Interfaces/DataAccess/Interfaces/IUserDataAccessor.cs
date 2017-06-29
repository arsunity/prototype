using Arsunity.Interfaces.DataAccess.Models;
using System.Collections.Generic;

namespace Arsunity.Interfaces.DataAccess.Interfaces
{
    public interface IUserDataAccessor
    {
        IEnumerable<User> GetAllUsers();
    }
}
