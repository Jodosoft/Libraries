// Copyright (c) 2023 Joe Lawry-Short
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

namespace Jodosoft.Collections
{
    public sealed class SortedDictionaryLookup<TKey, TValue> : IReadOnlyLookup<TKey, TValue> where TKey : notnull
    {
        private readonly SortedDictionary<TKey, TValue> _dictionary;

        public SortedDictionaryLookup(SortedDictionary<TKey, TValue> dictionary)
        {
            _dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
        }

        public TValue this[TKey key] => _dictionary[key];
        public IReadOnlyCollection<TKey> Keys => _dictionary.Keys;
        public IReadOnlyCollection<TValue> Values => _dictionary.Values;
        public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);
    }
}
