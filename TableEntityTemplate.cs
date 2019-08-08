using System.Collections.Generic;

namespace T4Sample
{
    public partial class TableEntityTemplate : ITextTemplate
    {
        private readonly Dictionary<string, string> _typeDictionary;

        public string NameSpace { get; }

        public TableInfo Table { get; }

        public TableEntityTemplate(Dictionary<string, string> typeDictionary, string nameSpace, TableInfo table)
            => (_typeDictionary, NameSpace, Table) = (typeDictionary, nameSpace, table);

        public string GetColumnType(ColumnInfo column)
            => _typeDictionary.TryGetValue(column.Type, out var n) ? n : column.Type
                + (column.NotNull ? "" : "?");
    }
}
