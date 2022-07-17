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
using System.Runtime.CompilerServices;
using Jodo.Numerics;

namespace Jodo.Primitives
{
    public static class BitConverterN
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBytes<N>(N value) where N : struct, INumeric<N>
            => BitConverter<N>.GetBytes(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N FromBytes<N>(byte[] bytes) where N : struct, INumeric<N>
            => BitConverter<N>.FromBytes(bytes);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N FromBytes<N>(IReadOnlyList<byte> bytes) where N : struct, INumeric<N>
            => BitConverter<N>.FromBytes(bytes);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Read<N>(IReadOnlyStream<byte> stream) where N : struct, INumeric<N>
            => BitConverter<N>.Read(stream);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<N>(IWriteOnlyStream<byte> stream, N value) where N : struct, INumeric<N>
            => BitConverter<N>.Write(stream, value);
    }
}
