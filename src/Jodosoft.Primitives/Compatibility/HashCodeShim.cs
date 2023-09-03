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
    [SuppressMessage("csharpsquid", "S2436:Types and methods should not have too many generic parameters", Justification = "Like-for-like shims for SDK methods")]
    [SuppressMessage("csharpsquid", "S107:Methods should not have too many parameters", Justification = "Like-for-like shims for SDK methods")]
    public static class HashCodeShim
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Combine<T1>(T1 value1)
        {
#if NETSTANDARD2_1_OR_GREATER
            return System.HashCode.Combine(value1);
#else
            return new { value1 }.GetHashCode();
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Combine<T1, T2>(T1 value1, T2 value2)
        {
#if NETSTANDARD2_1_OR_GREATER
            return System.HashCode.Combine(value1);
#else
            return new { value1, value2 }.GetHashCode();
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Combine<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
        {
#if NETSTANDARD2_1_OR_GREATER
            return System.HashCode.Combine(value1);
#else
            return new { value1, value2, value3 }.GetHashCode();
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Combine<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
        {
#if NETSTANDARD2_1_OR_GREATER
            return System.HashCode.Combine(value1, value2, value3, value4);
#else
            return new { value1, value2, value3, value4 }.GetHashCode();
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Combine<T1, T2, T3, T4, T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
#if NETSTANDARD2_1_OR_GREATER
            return System.HashCode.Combine(value1, value2, value3, value4, value5);
#else
            return new { value1, value2, value3, value4, value5 }.GetHashCode();
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Combine<T1, T2, T3, T4, T5, T6>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
        {
#if NETSTANDARD2_1_OR_GREATER
            return System.HashCode.Combine(value1, value2, value3, value4, value5, value6);
#else
            return new { value1, value2, value3, value4, value5, value6 }.GetHashCode();
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Combine<T1, T2, T3, T4, T5, T6, T7>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
        {
#if NETSTANDARD2_1_OR_GREATER
            return System.HashCode.Combine(value1, value2, value3, value4, value5, value6, value7);
#else
            return new { value1, value2, value3, value4, value5, value6, value7 }.GetHashCode();
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Combine<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8)
        {
#if NETSTANDARD2_1_OR_GREATER
            return System.HashCode.Combine(value1, value2, value3, value4, value5, value6, value7, value8);
#else
            return new { value1, value2, value3, value4, value5, value6, value7, value8 }.GetHashCode();
#endif
        }
    }
}
