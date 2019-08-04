using System.Collections.Generic;

namespace T4Sample
{
    public class ColumnInfo
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool IsPrimary { get; set; }

        public bool NotNull { get; set; }

        public string? Description { get; set; }
    }
}
