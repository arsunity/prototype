namespace Arsunity.Prototype.ViewModels
{
    using Arsunity.Grid.Attributes;
    using System;

    public class GridUserVm
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
