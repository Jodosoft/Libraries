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
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Jodo.Primitives
{
    public static class BitBuffer
    {
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<T>(T value, Stream stream) where T : struct, IProvider<IBitBuffer<T>>
            => DefaultProvider<T, IBitBuffer<T>>.Instance.Write(value, stream);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync<T>(T value, Stream stream) where T : struct, IProvider<IBitBuffer<T>>
            => await DefaultProvider<T, IBitBuffer<T>>.Instance.WriteAsync(value, stream);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Read<T>(Stream stream) where T : struct, IProvider<IBitBuffer<T>>
            => DefaultProvider<T, IBitBuffer<T>>.Instance.Read(stream);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<T> ReadAsync<T>(Stream stream) where T : struct, IProvider<IBitBuffer<T>>
            => await DefaultProvider<T, IBitBuffer<T>>.Instance.ReadAsync(stream);

        public static byte[] Serialize<T>(IEnumerable<T> values) where T : struct, IProvider<IBitBuffer<T>>
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            using IEnumerator<T> enumerator = values.GetEnumerator();
            if (!enumerator.MoveNext()) throw new InvalidOperationException("Sequence contains no elements");

            using Stream stream = new MemoryStream();
            while (enumerator.MoveNext())
            {
                DefaultProvider<T, IBitBuffer<T>>.Instance.Write(enumerator.Current, stream);
            }
            stream.Position = 0;
            byte[] result = new byte[stream.Length];
            _ = stream.Read(result, 0, result.Length);
            return result;
        }

        public static byte[] Serialize<T>(T value) where T : struct, IProvider<IBitBuffer<T>>
        {
            using Stream stream = new MemoryStream();
            DefaultProvider<T, IBitBuffer<T>>.Instance.Write(value, stream);
            stream.Position = 0;
            byte[] result = new byte[stream.Length];
            _ = stream.Read(result, 0, result.Length);
            return result;
        }

        public static async Task<byte[]> SerializeAsync<T>(T value) where T : struct, IProvider<IBitBuffer<T>>
        {
            using Stream stream = new MemoryStream();
            await DefaultProvider<T, IBitBuffer<T>>.Instance.WriteAsync(value, stream);
            stream.Position = 0;
            byte[] result = new byte[stream.Length];
            _ = await stream.ReadAsync(result, 0, result.Length, CancellationToken.None);
            return result;
        }

        public static T Deserialize<T>(byte[] buffer, int offset) where T : struct, IProvider<IBitBuffer<T>>
        {
            using Stream stream = new MemoryStream(buffer, offset, buffer.Length - offset);
            stream.Position = 0;
            T result = DefaultProvider<T, IBitBuffer<T>>.Instance.Read(stream);
            return result;
        }

        public static async Task<T> DeserializeAsync<T>(byte[] buffer, int offset) where T : struct, IProvider<IBitBuffer<T>>
        {
            using Stream stream = new MemoryStream(buffer, offset, buffer.Length - offset);
            stream.Position = 0;
            T result = await DefaultProvider<T, IBitBuffer<T>>.Instance.ReadAsync(stream);
            return result;
        }
    }
}
