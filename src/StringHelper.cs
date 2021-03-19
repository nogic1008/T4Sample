using System;

namespace T4Sample
{
    /// <summary>
    /// Extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Convert snake_case to PascalCase(UpperCamel).
        /// </summary>
        /// <param name="snakeCaseString">snake_case string.</param>
        /// <returns>PascalCase string.</returns>
        public static string ToPascalCase(this string snakeCaseString)
            => string.IsNullOrEmpty(snakeCaseString) ?
                snakeCaseString : ToCamelCaseInner(snakeCaseString.AsSpan(), true);

        /// <summary>
        /// Convert snake_case to camelCase(lowerCamel).
        /// </summary>
        /// <param name="snakeCaseString">snake_case string.</param>
        /// <returns>camelCase string.</returns>
        public static string ToCamelCase(this string snakeCaseString)
            => string.IsNullOrEmpty(snakeCaseString) ?
                snakeCaseString : ToCamelCaseInner(snakeCaseString.AsSpan(), false);

        /// <summary>
        /// Inner Method for <see cref="ToPascalCase(string)"/> and <see cref="ToCamelCase(string)"/>.
        /// </summary>
        /// <param name="source">snake_case chars span.</param>
        /// <param name="isUpper">First Letter is Upper or Lower.</param>
        /// <returns>(Upper|Lower) camelCase string.</returns>
        private static string ToCamelCaseInner(ReadOnlySpan<char> source, bool isUpper)
        {
            // if length is short, use stackalloc to avoid `new`.
            // TODO: use ArrayPool to avoid `new` completely.
            var buffer = source.Length <= 100 ?
                stackalloc char[source.Length] : new char[source.Length];

            int written = 0;
            foreach (char c in source)
            {
                if (c == '_')
                {
                    // (written != 0) means "Is Not First Letter".
                    // if camelCase and first letter, (isUpper | "Is Not First Letter") is false.
                    // if PascalCase and first letter, (isUpper | "Is Not First Letter") is true.
                    // if not first letter, (isUpper | "Is Not First Letter") is true whether isUpper is true or not.
                    isUpper |= (written != 0);
                    continue;
                }

                buffer[written++] = isUpper ? char.ToUpperInvariant(c) : char.ToLowerInvariant(c);
                isUpper = false;
            }
            return (written == 0) ? "" : new string(buffer.Slice(0, written));
        }
    }
}
