// ReSharper disable InheritdocConsiderUsage
namespace Arsunity.Prototype.Controllers
{
    using System;
    using Arsunity.Interfaces.DataAccess.Models;
    using Arsunity.Interfaces.Repositories;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The user data accessor.
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public HomeController(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        public IActionResult Index()
        {
            return this.View(this.repository);
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var user = this.repository.GetUserById(id);
            return this.View(user);
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpPost]
        public IActionResult Edit(User user)
        {
            this.repository.SaveUser(user);
            return this.RedirectToAction("Index");
        }
    }
}
