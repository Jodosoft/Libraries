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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Jodosoft.Primitives.Compatibility
{

    [SuppressMessage("csharpsquid", "S6640:Using unsafe code blocks is security-sensitive.", Justification = "Shims using verified .NET implementations.")]
    public static class DoubleShim
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFinite(double d)
        {
#if NETSTANDARD2_1_OR_GREATER
            return double.IsFinite(d);
#else
            long bits = BitConverterShim.DoubleToInt64Bits(d);
            return (bits & 0x7FFFFFFFFFFFFFFF) < 0x7FF0000000000000;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsNegative(double d)
        {
#if NETSTANDARD2_1_OR_GREATER
            return double.IsNegative(d);
#else
            return BitConverterShim.DoubleToInt64Bits(d) < 0;
#endif
        }

        public static unsafe bool IsNormal(double d)
        {
#if NETSTANDARD2_1_OR_GREATER
            return double.IsNormal(d);
#else
            long bits = BitConverterShim.DoubleToInt64Bits(d);
            bits &= 0x7FFFFFFFFFFFFFFF;
            return bits < 0x7FF0000000000000 && bits != 0 && (bits & 0x7FF0000000000000) != 0;
#endif
        }

        public static unsafe bool IsSubnormal(double d)
        {
#if NETSTANDARD2_1_OR_GREATER
            return double.IsSubnormal(d);
#else
            long bits = BitConverterShim.DoubleToInt64Bits(d);
            bits &= 0x7FFFFFFFFFFFFFFF;
            return bits < 0x7FF0000000000000 && bits != 0 && (bits & 0x7FF0000000000000) == 0;
#endif
        }
    }
}
