// ReSharper disable UnusedMember.Global
// ReSharper disable InheritdocConsiderUsage
// ReSharper disable ClassNeverInstantiated.Global
namespace Arsunity.Prototype.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Arsunity.Interfaces.DataAccess.Interfaces;
    using Arsunity.Interfaces.DataAccess.Models;
    using Arsunity.Interfaces.Repositories;
    using Arsunity.Grid.Repository;
    using Arsunity.Prototype.ViewModels;
    using System.Linq;
    using AutoMapper;

    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserRepository : GridRepository<GridUserVm>, IUserRepository
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
        protected override async Task<IEnumerable<GridUserVm>> LoadDataFromDb()
        {
            var models = await this.userDataAccessor.GetAllUsers();
            var result = models.Select(m => Mapper.Map<GridUserVm>(m)).ToList();
            return result;
        }
    }
}
