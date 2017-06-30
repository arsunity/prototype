namespace Arsunity.Prototype.Controllers
{
    using Arsunity.Interfaces.DataAccess.Interfaces;
    using Arsunity.Interfaces.DataAccess.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IUserDataAccessor userDataAccessor;

        public HomeController(IUserDataAccessor userDataAccessor)
        {
            this.userDataAccessor = userDataAccessor;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        public IActionResult Index()
        {
            var users = userDataAccessor.GetAllUsers().ToList();
            return this.View(users);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var user = userDataAccessor.GetUserById(id);
            return this.View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            userDataAccessor.SaveUser(user);
            return this.RedirectToAction("Index");
        }
    }
}
