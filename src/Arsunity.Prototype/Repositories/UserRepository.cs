// ReSharper disable UnusedMember.Global
// ReSharper disable InheritdocConsiderUsage
// ReSharper disable ClassNeverInstantiated.Global
namespace Arsunity.Prototype.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Arsunity.Interfaces.DataAccess.Interfaces;
    using Arsunity.Interfaces.DataAccess.Models;
    using Arsunity.Interfaces.Repositories;

    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserRepository : GridRepository<User>, IUserRepository
    {
        /// <summary>
        /// The user data accessor.
        /// </summary>
        private readonly IUserDataAccessor userDataAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="userDataAccessor">
        /// The user data accessor.
        /// </param>
        public UserRepository(IUserDataAccessor userDataAccessor)
        {
            this.userDataAccessor = userDataAccessor;
        }

        /// <summary>
        /// The get user by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// User data
        /// </returns>
        public User GetUserById(Guid id)
        {
            return this.userDataAccessor.GetUserById(id);
        }

        /// <summary>
        /// The save user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        public void SaveUser(User user)
        {
            this.userDataAccessor.SaveUser(user);
        }

        /// <summary>
        /// The load data from db.
        /// </summary>
        /// <returns>
        /// Users for grid
        /// </returns>
        protected override IEnumerable<User> LoadDataFromDb()
        {
            var users = this.userDataAccessor.GetAllUsers().ToList();
            return users;
        }
    }
}
