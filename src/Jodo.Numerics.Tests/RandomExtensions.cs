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
        public static TNumeric NextNumeric<TNumeric>(this Random random, TestBounds bounds) where TNumeric : struct, INumeric<TNumeric>
        {
            TNumeric result;
            do
            {
                result = random.NextNumeric<TNumeric>();
            } while (
                (bounds.HasFlag(TestBounds.Positive) && result.IsLessThanOrEqualTo(Numeric.Zero<TNumeric>())) ||
                (bounds.HasFlag(TestBounds.HighMagnitude) && MathN.Abs(result).IsLessThan(Numeric.Ten<TNumeric>())));

            if (bounds.HasFlag(TestBounds.LowSignificance))
            {
                while (MathN.Log10(MathN.Abs(result)).IsGreaterThan(ConvertN.ToNumeric<TNumeric>(3)))
                {
                    result = result.Divide(Numeric.Ten<TNumeric>());
                }
                result = MathN.Round(result, 2);
            }

            if (!Numeric.IsFinite(result))
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public static Vector2<TNumeric> NextVector2<TNumeric>(this Random random, TestBounds bounds) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2<TNumeric>(
                random.NextNumeric<TNumeric>(bounds),
                random.NextNumeric<TNumeric>(bounds));
        }

        public static Vector3<TNumeric> NextVector3<TNumeric>(this Random random, TestBounds bounds) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector3<TNumeric>(
                random.NextNumeric<TNumeric>(bounds),
                random.NextNumeric<TNumeric>(bounds),
                random.NextNumeric<TNumeric>(bounds));
        }
    }
}
