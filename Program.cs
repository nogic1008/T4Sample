using System;
using System.Collections.Generic;

namespace T4Sample
{
    class Program
    {
        static void Main()
        {
            var typeDef = new Dictionary<string, string>()
            {
                { "integer", "int" },
                { "varchar", "string" },
                { "date", "DateTime" },
            };

            var table = new TableInfo()
            {
                Name = "staff_master",
                Description = "Stores employee information.",
                Columns = new[]
                {
                    new ColumnInfo() { Name = "staff_id", Type = "integer", IsPrimary = true, NotNull = true },
                    new ColumnInfo() { Name = "staff_name", Type = "varchar", NotNull = true },
                    new ColumnInfo() { Name = "address", Type = "varchar", Description = "Home Address." },
                    new ColumnInfo() { Name = "created_date", Type = "date" },
                }
            };

            ITextTemplate template = new TableEntityTemplate(typeDef, "MyNameSpace", table);

            Console.WriteLine(template.TransformText());
        }
    }
}
