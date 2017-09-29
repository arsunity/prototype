// ReSharper disable ClassNeverInstantiated.Global
namespace Arsunity.DataAccess.DataInitializers
{
    using System;
    using System.Collections.Generic;

    using Arsunity.Interfaces.DataAccess.Interfaces;
    using Arsunity.Interfaces.DataAccess.Models;

    /// <summary>
    /// The data initializer.
    /// </summary>
    internal class DataInitializer : IDataInitializer
    {
        /// <summary>
        /// The user data accessor.
        /// </summary>
        private readonly IUserDataAccessor userDataAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataInitializer"/> class.
        /// </summary>
        /// <param name="userDataAccessor">
        /// The user data accessor.
        /// </param>
        public DataInitializer(IUserDataAccessor userDataAccessor)
        {
            this.userDataAccessor = userDataAccessor;
        }

        /// <summary>
        /// The init.
        /// </summary>
        public void Init()
        {
            this.InitUsers();
        }

        /// <summary>
        /// The init users.
        /// </summary>
        private void InitUsers()
        {
            if (!this.userDataAccessor.CheckUsers())
            {
                var users = new List<User>
                {
                    new User { Id = Guid.NewGuid(), Login = "Ivanov", Password = "Ivanov" },
                    new User { Id = Guid.NewGuid(), Login = "Petrov", Password = "Petrov" },
                    new User { Id = Guid.NewGuid(), Login = "Sidorov", Password = "Sidorov" },
                    new User { Id = Guid.NewGuid(), Login = "Pupkin", Password = "Pupkin" },
                };

                this.userDataAccessor.AddUsers(users);
            }
        }
    }
}
