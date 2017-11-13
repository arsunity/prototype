namespace Arsunity.Grid.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The grid context.
    /// </summary>
    public class GridContext
    {
        /// <summary>
        /// Gets or sets the titles.
        /// </summary>
        public IEnumerable<string> Titles { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public IEnumerable<GridRowData> Data { get; set; }

        /// <summary>
        /// Gets or sets the edit url.
        /// </summary>
        public string EditUrl { get; set; }
    }
}
