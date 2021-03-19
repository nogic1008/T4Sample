using System.Collections.Generic;

namespace T4Sample
{
    public partial class TableEntityTemplate : ITextTemplate
    {
        /// <summary>
        /// Assigns Databases Column Type Name to .NET Type Name.
        /// </summary>
        private readonly Dictionary<string, string> _typeDictionary;

        /// <summary>
        /// Entity's Namespace.
        /// </summary>
        public string NameSpace { get; }

        /// <summary>
        /// Table Data.
        /// </summary>
        public TableInfo Table { get; }

        /// <summary>
        /// Creates an Instance of TableEntityTemplate.
        /// </summary>
        /// <param name="typeDictionary">Assigns Databases Column Type Name to .NET Type Name.</param>
        /// <param name="nameSpace">Entity's Namespace.</param>
        /// <param name="table">Table Data.</param>
        public TableEntityTemplate(Dictionary<string, string> typeDictionary, string nameSpace, TableInfo table)
            => (_typeDictionary, NameSpace, Table) = (typeDictionary, nameSpace, table);

        /// <summary>
        /// Get .NET Type Name from typeDictionary.
        /// </summary>
        /// <param name="column">Column's Data.</param>
        /// <returns>
        /// Returns typeDictionary's value if found.
        /// Returns <see cref="ColumnInfo.Type"/> if not found.
        /// If the column is nullable, add "?" To the return value.
        /// </returns>
        public string GetColumnType(ColumnInfo column)
            => _typeDictionary.TryGetValue(column.Type, out string n) ? n : column.Type
                + (column.NotNull ? "" : "?");
    }
}
