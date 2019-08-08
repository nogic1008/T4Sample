using System;

namespace T4Sample
{
    /// <summary>
    /// Preprocessed text template.
    /// </summary>
    /// <remarks>
    /// This interface is used to avoid compile errors in code that calls T4 classes,
    /// and uses the "default implementation of interfaces" feature.
    /// Learn More: https://devblogs.microsoft.com/dotnet/default-implementations-in-interfaces/
    /// </remarks>
    public interface ITextTemplate
    {
        /// <summary>
        /// Generate the output text of the transformation.
        /// </summary>
        /// <returns>
        /// Throws <see cref="NotImplementedException"/>.
        /// After build, it should be overridden by the implementation.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Throws when the default implementation is called.
        /// </exception>
        string TransformText() => throw new NotImplementedException();
    }
}
