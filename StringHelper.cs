using System;
using System.Buffers;

namespace T4Sample
{
    public static class StringHelper
    {
        public static string ToPascalCase(this string snakeCaseString)
            => string.IsNullOrEmpty(snakeCaseString) ? snakeCaseString : ToCamelCaseInner(snakeCaseString.AsSpan(), true);
        public static string ToCamelCase(this string snakeCaseString)
            => string.IsNullOrEmpty(snakeCaseString) ? snakeCaseString : ToCamelCaseInner(snakeCaseString.AsSpan(), false);

        private static string ToCamelCaseInner(ReadOnlySpan<char> source, bool isUpper)
        {
            var buffer = ArrayPool<char>.Shared.Rent(source.Length);
            try
            {
                var bufferSpan = buffer.AsSpan();

                int written = 0;
                foreach (var c in source)
                {
                    if (c == '_')
                    {
                        // (written != 0) means "Is Not First Letter".
                        // if camelCase, isUpper switches `true` when "Is Not First Letter" and comes "_".
                        // if PascalCase, isUpper switches `true` when comes "_".
                        isUpper |= (written != 0);
                        continue;
                    }

                    bufferSpan[written++] = isUpper ? char.ToUpperInvariant(c) : char.ToLowerInvariant(c);
                    isUpper = false;
                }
                return (written == 0) ? "" : new string(bufferSpan.Slice(0, written));
            }
            finally
            {
                ArrayPool<char>.Shared.Return(buffer);
            }
        }
    }
}
