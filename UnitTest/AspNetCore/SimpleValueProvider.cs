// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Mvc.ModelBinding
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public sealed class SimpleValueProvider : Dictionary<string, object>, IValueProvider
    {
        private readonly CultureInfo _culture;

        public SimpleValueProvider()
            : this(null)
        {
        }

        public SimpleValueProvider(CultureInfo culture)
            : base(StringComparer.OrdinalIgnoreCase)
        {
            this._culture = culture ?? CultureInfo.InvariantCulture;
        }

        public bool ContainsPrefix(string prefix)
        {
            foreach (string key in this.Keys)
            {
                if (ModelStateDictionary.StartsWithPrefix(prefix, key))
                {
                    return true;
                }
            }

            return false;
        }

        public ValueProviderResult GetValue(string key)
        {
            if (this.TryGetValue(key, out var rawValue))
            {
                if (rawValue != null && rawValue.GetType().IsArray)
                {
                    var array = (Array)rawValue;

                    var stringValues = new string[array.Length];
                    for (var i = 0; i < array.Length; i++)
                    {
                        stringValues[i] = array.GetValue(i) as string ?? Convert.ToString(array.GetValue(i), this._culture);
                    }

                    return new ValueProviderResult(stringValues, this._culture);
                }
                else
                {
                    var stringValue = rawValue as string ?? Convert.ToString(rawValue, this._culture) ?? string.Empty;
                    return new ValueProviderResult(stringValue, this._culture);
                }
            }

            return ValueProviderResult.None;
        }
    }
}
