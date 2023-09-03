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
using System.Globalization;

namespace Jodosoft.Numerics
{
    public interface INumericStatic<TNumeric>
    {
        bool IsSigned { get; }
        bool IsReal { get; }
        bool HasNaN { get; }
        bool HasInfinity { get; }
        bool HasFloatingPoint { get; }

        TNumeric Epsilon { get; }
        TNumeric MaxUnit { get; }
        TNumeric MaxValue { get; }
        TNumeric MinUnit { get; }
        TNumeric MinValue { get; }
        TNumeric One { get; }
        TNumeric Zero { get; }

        bool IsFinite(TNumeric x);
        bool IsInfinity(TNumeric x);
        bool IsNaN(TNumeric x);
        bool IsNegative(TNumeric x);
        bool IsNegativeInfinity(TNumeric x);
        bool IsNormal(TNumeric x);
        bool IsPositiveInfinity(TNumeric x);
        bool IsSubnormal(TNumeric x);

        TNumeric Parse(string s, NumberStyles? style, IFormatProvider? provider);
    }
}
