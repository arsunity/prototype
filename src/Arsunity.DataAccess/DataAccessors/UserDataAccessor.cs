// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InheritdocConsiderUsage
namespace Arsunity.DataAccess.DataAccessors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Arsunity.DataAccess.DataContexts;
    using Arsunity.Interfaces.DataAccess.Interfaces;
    using Arsunity.Interfaces.DataAccess.Models;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The user data accessor.
    /// </summary>
    internal class UserDataAccessor : IUserDataAccessor
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly PrototypeDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDataAccessor"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public UserDataAccessor(PrototypeDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// The check users.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CheckUsers()
        {
            return this.context.Users.Any();
        }

        /// <summary>
        /// The get all users.
        /// </summary>
        /// <returns>
        /// All users
        /// </returns>
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await this.context.Users.ToListAsync();
        }

        /// <summary>
        /// The get user by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public User GetUserById(Guid id)
        {
            return this.context.Users.Where(x => x.Id == id).AsNoTracking().Single();
        }

        /// <summary>
        /// The save user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        public void SaveUser(User user)
        {
            var existUser = this.context.Users.SingleOrDefault(x => x.Id == user.Id);

            if (existUser == null)
            {
                this.context.Users.Add(user);
            }
            else
            {
                existUser.Login = user.Login;
                existUser.Password = user.Password;
            }

            this.context.SaveChanges();
        }

        /// <summary>
        /// The add users.
        /// </summary>
        /// <param name="users">
        /// The users.
        /// </param>
        public void AddUsers(IEnumerable<User> users)
        {
            this.context.Users.AddRange(users);
            this.context.SaveChanges();
        }
    }
}
