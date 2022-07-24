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
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Numeric;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics.Tests
{
    public static class FluentAssertionsExtensions
    {
        public static AndConstraint<ComparableTypeAssertions<TNumeric>> BeApproximately<TNumeric>(this ComparableTypeAssertions<TNumeric> parent, double expected, string because = "", params object[] becauseArgs) where TNumeric : struct, INumeric<TNumeric>
        {
            if (!DoubleCompat.IsFinite(expected)) throw new ArgumentOutOfRangeException(nameof(expected), expected, "Must be finite.");

            double actual = ConvertN.ToDouble((TNumeric)parent.Subject);
            if (Numeric.IsIntegral<TNumeric>())
            {
                double expectedValue = Math.Truncate(expected);
                Execute.Assertion
                    .ForCondition(actual == expectedValue)
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:value} to be {0} (integral equivalent to {1}){reason}, but it was {2}.", expectedValue, expected, actual);
            }
            else
            {
                double expectedValue = Math.Round(expected, 2);
                double actualValue = Math.Round(actual, 2);
                Execute.Assertion
                    .ForCondition(actualValue == expectedValue)
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:value} to be approximately {0}{reason}, but it was {1}.", expectedValue, actualValue);
            }

            return new AndConstraint<ComparableTypeAssertions<TNumeric>>(parent);
        }

        public static AndConstraint<ComparableTypeAssertions<TNumeric>> BeApproximately<TNumeric>(this ComparableTypeAssertions<TNumeric> parent, TNumeric expected, string because = "", params object[] becauseArgs) where TNumeric : struct, INumeric<TNumeric>
        {
            if (!Numeric.IsFinite(expected)) throw new ArgumentOutOfRangeException(nameof(expected), expected, "Must be finite.");

            TNumeric actual = (TNumeric)parent.Subject;
            TNumeric difference = MathN.Max(actual, expected).Subtract(MathN.Min(actual, expected));

            TNumeric tolerance = expected.IsGreaterThan(Numeric.MinUnit<TNumeric>()) && expected.IsLessThan(Numeric.MaxUnit<TNumeric>()) ?
                Numeric.One<TNumeric>().Divide(Numeric.Ten<TNumeric>()) :
                MathN.Abs(expected.Divide(Numeric.Ten<TNumeric>()));

            Execute.Assertion
                .ForCondition(difference.IsLessThanOrEqualTo(tolerance))
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:value} to be approximately {0}{reason}, but it was {1} (difference of {2}).",
                expected, parent.Subject, difference);

            return new AndConstraint<ComparableTypeAssertions<TNumeric>>(parent);
        }
    }
}
