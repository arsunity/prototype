// ReSharper disable InheritdocConsiderUsage
namespace Arsunity.Prototype.Components
{
    using Arsunity.Interfaces.Grid;
    using Arsunity.Interfaces.Repositories;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The grid view component.
    /// </summary>
    public class GridViewComponent : ViewComponent
    {
        /// <summary>
        /// The invoke.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        /// <param name="editUrl">
        /// The edit Url.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public IViewComponentResult Invoke(IRepository repository, string editUrl)
        {
            var gridContext = new GridContext { Titles = repository.Titles(), Data = repository.GetGridData(), EditUrl = editUrl };
            return this.View(gridContext);
        }
    }
}
