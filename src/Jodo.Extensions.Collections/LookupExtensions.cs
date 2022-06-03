// Copyright (c) 2022 Joseph J. Short
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Jodo.Extensions.Collections
{
    public static class LookupExtensions
    {
        public static bool TryGetValue<TKey, TValue>(this IReadOnlyLookup<TKey, TValue> instance, TKey key, out TValue value)
        {
            if (instance.ContainsKey(key))
            {
                value = instance[key];
                return true;
            }
            value = (new TValue[1])[0];
            return false;
        }

        public static IReadOnlyLookup<TKey, TValue> ToReadOnlyLookup<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary) where TKey : notnull
            => new DictionaryLookup<TKey, TValue>(dictionary.ToDictionary(x => x.Key, x => x.Value));

        public static IReadOnlyLookup<TKey, TSource> ToReadOnlyLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) where TKey : notnull
            => new DictionaryLookup<TKey, TSource>(source.ToDictionary(keySelector));

        public static IReadOnlyLookup<TKey, TElement> ToReadOnlyLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TKey : notnull
            => new DictionaryLookup<TKey, TElement>(source.ToDictionary(keySelector, elementSelector));
    }
}
