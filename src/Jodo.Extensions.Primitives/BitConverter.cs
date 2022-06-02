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

namespace Jodo.Extensions.Primitives
{
    public static class BitConverter<T> where T : struct, IProvider<IBitConverter<T>>
    {
        private static readonly IBitConverter<T> Default = default(T).GetInstance();

        public static ReadOnlySpan<byte> GetBytes(T value)
        {
            var list = new List<byte>();
            Default.Write(value, list.AsWriteOnlyStream());
            return list.ToArray();
        }

        public static T FromBytes(ReadOnlySpan<byte> bytes)
        {
            return Default.Read(bytes.ToArray().AsReadOnlyStream());
        }

        public static T FromBytes(IReadOnlyList<byte> bytes)
        {
            return Default.Read(bytes.AsReadOnlyStream());
        }

        public static T Read(IReadOnlyStream<byte> stream)
        {
            return Default.Read(stream);
        }

        public static void Write(IWriteOnlyStream<byte> stream, T value)
        {
            Default.Write(value, stream);
        }
    }
}
