namespace Arsunity.Grid.Interfaces
{
    using Arsunity.Grid.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// The header.
        /// </summary>
        /// <returns>
        /// Grid table titles
        /// </returns>
        List<string> Titles();

        /// <summary>
        /// The get grid data.
        /// </summary>
        /// <returns>
        /// Grid data
        /// </returns>
        Task<IEnumerable<GridRowData>> GetGridData();
    }
}