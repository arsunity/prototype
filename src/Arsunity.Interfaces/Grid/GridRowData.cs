// ReSharper disable ClassNeverInstantiated.Global
namespace Arsunity.Interfaces.Grid
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The grid row data.
    /// </summary>
    public class GridRowData
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the cells.
        /// </summary>
        public IList<GridCellData> Cells { get; set; }
    }
}
