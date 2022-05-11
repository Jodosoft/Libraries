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
    public interface IMath<T> where T : struct, INumeric<T>
    {
        T E { get; }
        T PI { get; }
        T Epsilon { get; }
        T MaxValue { get; }
        T MinValue { get; }
        T MaxUnit { get; }
        T MinUnit { get; }
        T Zero { get; }
        T One { get; }
        bool IsSigned { get; }
        bool IsReal { get; }

        bool IsGreaterThan(in T x, in T y);
        bool IsGreaterThanOrEqualTo(in T x, in T y);
        bool IsLessThan(in T x, in T y);
        bool IsLessThanOrEqualTo(in T x, in T y);
        double ToDouble(in T x, in double offset);
        float ToSingle(in T x, in float offset);
        int Sign(in T x);
        T Abs(in T x);
        T Acos(in T x);
        T Acosh(in T x);
        T Add(in T x, in T y);
        T Asin(in T x);
        T Asinh(in T x);
        T Atan(in T x);
        T Atan2(in T x, in T y);
        T Atanh(in T x);
        T Cbrt(in T x);
        T Ceiling(in T x);
        T Clamp(in T x, in T bound1, in T bound2);
        T Convert(in byte value);
        T Cos(in T x);
        T Cosh(in T x);
        T DegreesToRadians(in T x);
        T DegreesToTurns(in T x);
        T Divide(in T x, in T y);
        T Exp(in T x);
        T Floor(in T x);
        T IEEERemainder(in T x, in T y);
        T Log(in T x);
        T Log(in T x, in T y);
        T Log10(in T x);
        T Max(in T x, in T y);
        T Min(in T x, in T y);
        T Multiply(in T x, in T y);
        T Negative(in T x);
        T Positive(in T x);
        T Pow(in T x, in byte y);
        T Pow(in T x, in T y);
        T RadiansToDegrees(in T x);
        T RadiansToTurns(in T x);
        T Remainder(in T x, in T y);
        T Round(in T x);
        T Round(in T x, in int digits);
        T Round(in T x, in int digits, in MidpointRounding mode);
        T Round(in T x, in MidpointRounding mode);
        T Sin(in T x);
        T Sinh(in T x);
        T Sqrt(in T x);
        T Subtract(in T x, in T y);
        T Tan(in T x);
        T Tanh(in T x);
        T Truncate(in T x);
        T TurnsToDegrees(in T x);
        T TurnsToRadians(in T x);
    }
}
