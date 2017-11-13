// ReSharper disable InheritdocConsiderUsage
namespace Arsunity.Grid.Attributes
{
    using System;

    /// <summary>
    /// The grid title attribute.
    /// </summary>
    public class GridTitleAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        private string title;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridTitleAttribute"/> class.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        public GridTitleAttribute(string title)
        {
            this.title = title;
        }
    }
}
