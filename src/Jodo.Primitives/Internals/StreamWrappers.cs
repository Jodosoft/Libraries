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

namespace Jodo.Primitives.Internals
{
    internal static class StreamWrappers
    {
        internal sealed class ListReadOnly<T> : IReader<T>
        {
            private readonly IReadOnlyList<T> _list;
            private int _position;

            public ListReadOnly(IReadOnlyList<T> list)
            {
                _list = list ?? throw new ArgumentNullException(nameof(list));
                _position = 0;
            }

            public T[] Read(int count)
            {
                if (_position + count > _list.Count) throw new ArgumentOutOfRangeException(
                    nameof(count), count, "There are not enough bytes left in the stream.");

                T[]? results = new T[count];
                for (int i = 0; i < count; i++)
                {
                    results[i] = _list[_position + i];
                }
                _position += count;
                return results;
            }
        }

        internal sealed class CollectionWriteOnly<T> : IWriter<T>
        {
            private readonly ICollection<T> _collection;

            public CollectionWriteOnly(ICollection<T> collection)
            {
                _collection = collection ?? throw new ArgumentNullException(nameof(collection));
            }

            public void Write(T value) => _collection.Add(value);
        }
    }
}
