using System;
using Arsunity.Interfaces.DataAccess.Interfaces;
using System.Collections.Generic;
using Arsunity.Interfaces.DataAccess.Models;

namespace Arsunity.DataAccess.DataInitializers
{
    internal class DataInitializer : IDataInitializer
    {
        private readonly IUserDataAccessor userDataAccessor;

        public DataInitializer(IUserDataAccessor userDataAccessor)
        {
            this.userDataAccessor = userDataAccessor;
        }

        public void Init()
        {
            InitUsers();
        }

        private void InitUsers()
        {
            if (!userDataAccessor.CheckUsers())
            {
                var users = new List<User>
                {
                    new User { Id = Guid.NewGuid(), Login = "Ivanov", Password = "Ivanov" },
                    new User { Id = Guid.NewGuid(), Login = "Petrov", Password = "Petrov" },
                    new User { Id = Guid.NewGuid(), Login = "Sidorov", Password = "Sidorov" },
                    new User { Id = Guid.NewGuid(), Login = "Pupkin", Password = "Pupkin" },
                };

                userDataAccessor.AddUsers(users);
            }
        }
    }
}
