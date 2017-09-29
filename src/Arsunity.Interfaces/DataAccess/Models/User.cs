namespace Arsunity.Interfaces.DataAccess.Models
{
    using System;

    using Arsunity.Interfaces.Repositories.Attributes;

    /// <summary>
    /// The user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [KeyId]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        [GridTitle("Логин")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [GridTitle("Пароль")]
        public string Password { get; set; }
    }
}
