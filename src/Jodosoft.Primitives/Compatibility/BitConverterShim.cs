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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Jodosoft.Primitives.Compatibility
{
    [SuppressMessage("csharpsquid", "S6640:Using unsafe code blocks is security-sensitive.", Justification = "Shims using verified .NET implementations.")]
    public static class BitConverterShim
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int SingleToInt32Bits(float value)
        {
#if NETSTANDARD2_1
            return BitConverter.SingleToInt32Bits(value);
#else
            return *(int*)&value;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe float Int32BitsToSingle(int value)
        {
#if NETSTANDARD2_1
            return BitConverter.Int32BitsToSingle(value);
#else
            return *(float*)&value;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe long DoubleToInt64Bits(double value)
        {
#if NETSTANDARD2_1
            return BitConverter.DoubleToInt64Bits(value);
#else
            return *(long*)&value;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe double Int64BitsToDouble(long value)
        {
#if NETSTANDARD2_1
            return BitConverter.Int64BitsToDouble(value);
#else
            return *(double*)&value;
#endif
        }
    }
}
