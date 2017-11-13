﻿namespace Arsunity.Interfaces.DataAccess.Models
{
    using System;

    /// <summary>
    /// The user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}
