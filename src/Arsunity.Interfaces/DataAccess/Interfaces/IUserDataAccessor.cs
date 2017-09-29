namespace Arsunity.Interfaces.DataAccess.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Arsunity.Interfaces.DataAccess.Models;

    /// <summary>
    /// The UserDataAccessor interface.
    /// </summary>
    public interface IUserDataAccessor
    {
        /// <summary>
        /// The check users.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool CheckUsers();

        /// <summary>
        /// The get all users.
        /// </summary>
        /// <returns>
        /// All users
        /// </returns>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// The get user by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        User GetUserById(Guid id);

        /// <summary>
        /// The save user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        void SaveUser(User user);

        /// <summary>
        /// The add users.
        /// </summary>
        /// <param name="users">
        /// The users.
        /// </param>
        void AddUsers(IEnumerable<User> users);
    }
}
