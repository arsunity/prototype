namespace Arsunity.Prototype.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The user.
    /// </summary>
    public class UserVm
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        [Required(ErrorMessage = "Требуется логин")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Размер пароля должен быть в диапазоне от 3 до 10 символов")]
        [RegularExpression(@"(.*\d+.*)", ErrorMessage = "Должна быть хотя бы одна цифра")]
        public string Password { get; set; }
    }
}
