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

        bool IsGreaterThan(T x, T y);
        bool IsGreaterThanOrEqualTo(T x, T y);
        bool IsLessThan(T x, T y);
        bool IsLessThanOrEqualTo(T x, T y);
        double ToDouble(T x, double offset);
        float ToSingle(T x, float offset);
        int Sign(T x);
        T Abs(T x);
        T Acos(T x);
        T Acosh(T x);
        T Add(T x, T y);
        T Asin(T x);
        T Asinh(T x);
        T Atan(T x);
        T Atan2(T x, T y);
        T Atanh(T x);
        T Cbrt(T x);
        T Ceiling(T x);
        T Clamp(T x, T bound1, T bound2);
        T Cos(T x);
        T Cosh(T x);
        T DegreesToRadians(T x);
        T DegreesToTurns(T x);
        T Divide(T x, T y);
        T Exp(T x);
        T Floor(T x);
        T IEEERemainder(T x, T y);
        T Log(T x);
        T Log(T x, T y);
        T Log10(T x);
        T Max(T x, T y);
        T Min(T x, T y);
        T Multiply(T x, T y);
        T Negative(T x);
        T Positive(T x);
        T Pow(T x, byte y);
        T Pow(T x, T y);
        T RadiansToDegrees(T x);
        T RadiansToTurns(T x);
        T Remainder(T x, T y);
        T Round(T x);
        T Round(T x, int digits);
        T Round(T x, int digits, MidpointRounding mode);
        T Round(T x, MidpointRounding mode);
        T Sin(T x);
        T Sinh(T x);
        T Sqrt(T x);
        T Subtract(T x, T y);
        T Tan(T x);
        T Tanh(T x);
        T Truncate(T x);
        T TurnsToDegrees(T x);
        T TurnsToRadians(T x);
    }
}
