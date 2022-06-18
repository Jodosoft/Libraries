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

using System.Runtime.CompilerServices;

namespace Jodo.Primitives.Compatibility
{
    public static class SingleCompat
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFinite(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return float.IsFinite(f);
#else
            int bits = BitConverterCompat.SingleToInt32Bits(f);
            return (bits & 0x7FFFFFFF) < 0x7F800000;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsNegative(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return float.IsNegative(f);
#else
            return BitConverterCompat.SingleToInt32Bits(f) < 0;
#endif
        }

        public static unsafe bool IsNormal(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return float.IsNormal(f);
#else
            int bits = BitConverterCompat.SingleToInt32Bits(f);
            bits &= 0x7FFFFFFF;
            return bits < 0x7F800000 && bits != 0 && (bits & 0x7F800000) != 0;
#endif
        }

        public static unsafe bool IsSubnormal(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return float.IsSubnormal(f);
#else
            int bits = BitConverterCompat.SingleToInt32Bits(f);
            bits &= 0x7FFFFFFF;
            return bits < 0x7F800000 && bits != 0 && (bits & 0x7F800000) == 0;
#endif
        }
    }
}
