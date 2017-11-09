// ReSharper disable UnusedMember.Global
// ReSharper disable InheritdocConsiderUsage
namespace Arsunity.Prototype.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Arsunity.Interfaces.Grid;
    using Arsunity.Interfaces.Repositories;
    using Arsunity.Interfaces.Repositories.Attributes;

    /// <summary>
    /// The grid repository.
    /// </summary>
    /// <typeparam name="T">
    /// Type of grid items
    /// </typeparam>
    public abstract class GridRepository<T> : IRepository
        where T : class
    {
        /// <summary>
        /// The titles.
        /// </summary>
        /// <returns>
        /// Grid table titles
        /// </returns>
        public List<string> Titles()
        {
            var type = typeof(T);
            var properties = type.GetProperties();

            var result = new List<string>();
            foreach (var propertyInfo in properties)
            {
                var attr = propertyInfo.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(GridTitleAttribute));
                if (attr != null)
                {
                    result.Add((string)attr.ConstructorArguments.First().Value);
                }
            }

            return result;
        }

        /// <summary>
        /// The get grid data.
        /// </summary>
        /// <returns>
        /// Grid data
        /// </returns>
        public async Task<IEnumerable<GridRowData>> GetGridData()
        {
            var result = new List<GridRowData>();

            var entities = await this.LoadDataFromDb();
            foreach (var entity in entities)
            {
                var entityType = entity.GetType();
                var properties = entityType.GetProperties();
                var idProperty  = properties.FirstOrDefault(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(KeyIdAttribute)));
                if (idProperty == null)
                {
                    continue;
                }

                var keyProperties = properties.Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(GridTitleAttribute)));
                var values = keyProperties.Select(p => p.GetValue(entity)?.ToString());
                result.Add(new GridRowData { Id = (Guid)idProperty.GetValue(entity), Cells = new List<GridCellData>(values.Select(v => new GridCellData { Value = v })) });
            }

            return result;
        }

        /// <summary>
        /// The load data from db.
        /// </summary>
        /// <returns>
        /// Grid data from database
        /// </returns>
        protected abstract Task<IEnumerable<T>> LoadDataFromDb();
    }
}
