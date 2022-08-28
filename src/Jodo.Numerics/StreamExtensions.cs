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

using System.Collections.Generic;
using Jodo.Numerics.Internals;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    public static class StreamExtensions
    {
        public static T Read<T>(this IReader<byte> stream) where T : struct, IProvider<INumericBitConverter<T>>
        {
            return BitConverterN.Read<T>(stream);
        }

        public static void Write<T>(this IWriter<byte> stream, T value) where T : struct, IProvider<INumericBitConverter<T>>
        {
            BitConverterN.Write(stream, value);
        }

        public static void Write<T>(this IWriter<T> stream, T[] values)
        {
            foreach (T value in values)
            {
                stream.Write(value);
            }
        }

        public static IWriter<T> AsWriteOnlyStream<T>(this ICollection<T> collection)
           => new StreamWrappers.CollectionWriteOnly<T>(collection);

        public static IReader<T> AsReadOnlyStream<T>(this IReadOnlyList<T> collection)
            => new StreamWrappers.ListReadOnly<T>(collection);
    }
}
