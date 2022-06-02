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

namespace Jodo.Extensions.Numerics
{
    public interface INumericFunctions<N>
    {
        bool HasFloatingPoint { get; }
        bool IsReal { get; }
        bool IsSigned { get; }

        N Epsilon { get; }
        N MaxUnit { get; }
        N MaxValue { get; }
        N MinUnit { get; }
        N MinValue { get; }
        N One { get; }
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
    }
}
