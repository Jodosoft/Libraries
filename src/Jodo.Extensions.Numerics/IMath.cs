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

namespace Jodo.Extensions.Numerics
{
    public interface IMath<N> where N : struct, INumeric<N>
    {
        bool IsReal { get; }
        bool IsSigned { get; }
        N E { get; }
        N Epsilon { get; }
        N MaxUnit { get; }
        N MaxValue { get; }
        N MinUnit { get; }
        N MinValue { get; }
        N One { get; }
        N PI { get; }
        N Tau { get; }
        N Ten { get; }
        N Two { get; }
        N Zero { get; }

        bool IsFinite(N x);
        bool IsInfinity(N x);
        bool IsNaN(N x);
        bool IsNegative(N x);
        bool IsNegativeInfinity(N x);
        bool IsNormal(N x);
        bool IsPositiveInfinity(N x);
        bool IsSubnormal(N x);
        int Sign(N x);

        N Abs(N x);
        N Acos(N x);
        N Acosh(N x);
        N Asin(N x);
        N Asinh(N x);
        N Atan(N x);
        N Atan2(N x, N y);
        N Atanh(N x);
        N Cbrt(N x);
        N Ceiling(N x);
        N Clamp(N x, N bound1, N bound2);
        N Cos(N x);
        N Cosh(N x);
        N DegreesToRadians(N degrees);
        N Exp(N x);
        N Floor(N x);
        N IEEERemainder(N x, N y);
        N Log(N x);
        N Log(N x, N y);
        N Log10(N x);
        N Max(N x, N y);
        N Min(N x, N y);
        N Pow(N x, N y);
        N RadiansToDegrees(N radians);
        N Round(N x);
        N Round(N x, int digits);
        N Round(N x, int digits, MidpointRounding mode);
        N Round(N x, MidpointRounding mode);
        N Sin(N x);
        N Sinh(N x);
        N Sqrt(N x);
        N Tan(N x);
        N Tanh(N x);
        N Truncate(N x);
    }
}
