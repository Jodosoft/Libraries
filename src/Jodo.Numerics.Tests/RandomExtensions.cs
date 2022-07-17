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

namespace Jodo.Numerics.Tests
{
    public static class RandomExtensions
    {
        public static N NextNumeric<N>(this Random random, TestBounds bounds) where N : struct, INumeric<N>
        {
            N result;
            do
            {
                result = random.NextNumeric<N>();
            } while (
                (bounds.HasFlag(TestBounds.Positive) && result.IsLessThanOrEqualTo(Numeric<N>.Zero)) ||
                (bounds.HasFlag(TestBounds.HighMagnitude) && MathN.Abs(result).IsLessThan(Numeric<N>.Ten)));

            if (bounds.HasFlag(TestBounds.LowSignificance))
            {
                while (MathN.Log10(MathN.Abs(result)).IsGreaterThan(ConvertN.ToNumeric<N>(3)))
                {
                    result = result.Divide(Numeric<N>.Ten);
                }
                result = MathN.Round(result, 2);
            }

            if (!Numeric<N>.IsFinite(result))
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public static Vector2<N> NextVector2<N>(this Random random, TestBounds bounds) where N : struct, INumeric<N>
        {
            return new Vector2<N>(
                random.NextNumeric<N>(bounds),
                random.NextNumeric<N>(bounds));
        }

        public static Vector3<N> NextVector3<N>(this Random random, TestBounds bounds) where N : struct, INumeric<N>
        {
            return new Vector3<N>(
                random.NextNumeric<N>(bounds),
                random.NextNumeric<N>(bounds),
                random.NextNumeric<N>(bounds));
        }
    }
}
