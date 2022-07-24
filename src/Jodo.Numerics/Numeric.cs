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

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    public static class Numeric
    {
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFloatingPoint<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.HasFloatingPoint;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasInfinity<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.HasInfinity;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasNaN<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.HasNaN;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsReal<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.IsReal;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIntegral<T>() where T : struct, INumeric<T>
            => !Provider<T, INumericStatic<T>>.Default.IsReal;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSigned<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.IsSigned;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsUnsigned<T>() where T : struct, INumeric<T>
            => !Provider<T, INumericStatic<T>>.Default.IsSigned;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Epsilon<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.Epsilon;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxUnit<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.MaxUnit;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxValue<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.MaxValue;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MinUnit<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.MinUnit;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MinValue<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.MinValue;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T One<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.One;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Ten<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.Ten;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Two<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.Two;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Zero<T>() where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.Zero;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFinite<T>(T x) where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.IsFinite(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinity<T>(T x) where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.IsInfinity(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN<T>(T x) where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.IsNaN(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegative<T>(T x) where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.IsNegative(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegativeInfinity<T>(T x) where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.IsNegativeInfinity(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNormal<T>(T x) where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.IsNormal(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPositiveInfinity<T>(T x) where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.IsPositiveInfinity(x);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubnormal<T>(T x) where T : struct, INumeric<T>
            => Provider<T, INumericStatic<T>>.Default.IsSubnormal(x);
    }
}
