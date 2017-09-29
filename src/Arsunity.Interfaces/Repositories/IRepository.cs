namespace Arsunity.Interfaces.Repositories
{
    using System.Collections.Generic;

    using Arsunity.Interfaces.Grid;

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
        IEnumerable<GridRowData> GetGridData();
    }
}