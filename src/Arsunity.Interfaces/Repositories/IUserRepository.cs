namespace Arsunity.Interfaces.Repositories
{
    using System;

    using Arsunity.Interfaces.DataAccess.Models;

    /// <summary>
    /// The UserRepository interface.
    /// </summary>
    public interface IUserRepository
    {
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
    }
}