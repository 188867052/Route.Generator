namespace Route.Generator.Shared.Utilities
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using JetBrains.Annotations;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    [DebuggerStepThrough]
    internal static class DictionaryExtensions
    {
        /// <summary>
        ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
        ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
        ///     any release. You should only use it directly in your code with extreme caution and knowing that
        ///     doing so can result in application failures when updating to a new Entity Framework Core release.
        /// </summary>
        public static TValue GetOrAddNew<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> source,
            [NotNull] TKey key)
            where TValue : new()
        {
            if (!source.TryGetValue(key, out var value))
            {
                value = new TValue();
                source.Add(key, value);
            }

            return value;
        }

        /// <summary>
        ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
        ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
        ///     any release. You should only use it directly in your code with extreme caution and knowing that
        ///     doing so can result in application failures when updating to a new Entity Framework Core release.
        /// </summary>
        public static TValue Find<TKey, TValue>(
            [NotNull] this IReadOnlyDictionary<TKey, TValue> source,
            [NotNull] TKey key)
            => !source.TryGetValue(key, out var value) ? default : value;
    }
}
