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

namespace Jodo.Numerics
{
    public interface IMath<TNumeric>
    {
        TNumeric E { get; }
        TNumeric PI { get; }
        TNumeric Tau { get; }

        int Sign(TNumeric x);
        TNumeric Abs(TNumeric value);
        TNumeric Acos(TNumeric x);
        TNumeric Acosh(TNumeric x);
        TNumeric Asin(TNumeric x);
        TNumeric Asinh(TNumeric x);
        TNumeric Atan(TNumeric x);
        TNumeric Atan2(TNumeric x, TNumeric y);
        TNumeric Atanh(TNumeric x);
        TNumeric Cbrt(TNumeric x);
        TNumeric Ceiling(TNumeric x);
        TNumeric Clamp(TNumeric x, TNumeric bound1, TNumeric bound2);
        TNumeric Cos(TNumeric x);
        TNumeric Cosh(TNumeric x);
        TNumeric Exp(TNumeric x);
        TNumeric Floor(TNumeric x);
        TNumeric IEEERemainder(TNumeric x, TNumeric y);
        TNumeric Log(TNumeric x);
        TNumeric Log(TNumeric x, TNumeric y);
        TNumeric Log10(TNumeric x);
        TNumeric Max(TNumeric x, TNumeric y);
        TNumeric Min(TNumeric x, TNumeric y);
        TNumeric Pow(TNumeric x, TNumeric y);
        TNumeric Round(TNumeric x);
        TNumeric Round(TNumeric x, int digits);
        TNumeric Round(TNumeric x, int digits, MidpointRounding mode);
        TNumeric Round(TNumeric x, MidpointRounding mode);
        TNumeric Sin(TNumeric x);
        TNumeric Sinh(TNumeric x);
        TNumeric Sqrt(TNumeric x);
        TNumeric Tan(TNumeric x);
        TNumeric Tanh(TNumeric x);
        TNumeric Truncate(TNumeric x);
    }
}
