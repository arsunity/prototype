// ReSharper disable InheritdocConsiderUsage
namespace Arsunity.Grid.Components
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Arsunity.Grid.Interfaces;
    using Arsunity.Grid.Models;

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
        public async Task<IViewComponentResult> InvokeAsync(IRepository repository, string editUrl)
        {
            var gridContext = new GridContext { Titles = repository.Titles(), Data = await repository.GetGridData(), EditUrl = editUrl };
            return this.View(gridContext);
        }
    }
}
