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
using System.IO;

namespace Jodosoft.Primitives
{
    public static class BinaryConvert
    {
        public static byte[] Serialize<T>(IEnumerable<T> values) where T : struct, IProvider<IBinaryIO<T>>
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            using IEnumerator<T> enumerator = values.GetEnumerator();
            if (!enumerator.MoveNext()) throw new InvalidOperationException("Sequence contains no elements");

            using Stream stream = new MemoryStream();
            using BinaryWriter writer = new BinaryWriter(stream);
            while (enumerator.MoveNext())
            {
                DefaultProvider<T, IBinaryIO<T>>.Instance.Write(writer, enumerator.Current);
            }
            stream.Position = 0;
            byte[] result = new byte[stream.Length];
            _ = stream.Read(result, 0, result.Length);
            return result;
        }

        public static byte[] Serialize<T>(T value) where T : struct, IProvider<IBinaryIO<T>>
        {
            using Stream stream = new MemoryStream();
            using BinaryWriter writer = new BinaryWriter(stream);
            DefaultProvider<T, IBinaryIO<T>>.Instance.Write(writer, value);
            stream.Position = 0;
            byte[] result = new byte[stream.Length];
            _ = stream.Read(result, 0, result.Length);
            return result;
        }

        public static T Deserialize<T>(byte[] buffer, int offset) where T : struct, IProvider<IBinaryIO<T>>
        {
            using Stream stream = new MemoryStream(buffer, offset, buffer.Length - offset);
            using BinaryReader reader = new BinaryReader(stream);
            stream.Position = 0;
            T result = DefaultProvider<T, IBinaryIO<T>>.Instance.Read(reader);
            return result;
        }
    }
}
