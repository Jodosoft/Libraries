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

using FluentAssertions.Execution;
using FluentAssertions.Numeric;
using Jodo.Extensions.Numerics;
using System;

namespace FluentAssertions
{
    public static class FluentAssertionsExtensions
    {
        public static AndConstraint<ComparableTypeAssertions<T>> BeCheckedNumericEquivalentTo<T>(this ComparableTypeAssertions<T> parent, double expected, string because = "", params object[] becauseArgs) where T : struct, INumeric<T>
        {
            var actual = ((T)parent.Subject).ToDouble();

            if (double.IsNaN(expected))
            {
                Execute.Assertion
                  .ForCondition(actual == 0)
                  .BecauseOf(because, becauseArgs)
                  .FailWith("Expected {context:value} to be 0 (equivalent to NaN){reason}, but it was {0}.", actual);
            }
            else if (double.IsPositiveInfinity(expected))
            {
                var expectedValue = Constants<T>.MaxValue.ToDouble();
                Execute.Assertion
                  .ForCondition(actual == expectedValue)
                  .BecauseOf(because, becauseArgs)
                  .FailWith("Expected {context:value} to be 0 (MaxValue equivalent to PositiveInfinity){reason}, but it was {1}.", expectedValue, actual);
            }
            else if (double.IsNegativeInfinity(expected))
            {
                var expectedValue = Constants<T>.MinValue.ToDouble();
                Execute.Assertion
                  .ForCondition(actual == expectedValue)
                  .BecauseOf(because, becauseArgs)
                  .FailWith("Expected {context:value} to be 0 (MinValue equivalent to NegativeInfinity){reason}, but it was {1}.", expectedValue, actual);
            }
            else if (expected < 0 && !Constants<T>.IsSigned)
            {
                Execute.Assertion
                    .ForCondition(actual == 0)
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:value} to be 0 (unsigned equivalent to {0}){reason}, but it was {1}.", expected, actual);
            }
            else if (expected > Constants<T>.MaxValue.ToDouble())
            {
                var expectedValue = Constants<T>.MaxValue.ToDouble();
                Execute.Assertion
                    .ForCondition(actual == expectedValue)
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:value} to be {0} (checked/clamped version of {1}){reason}, but it was {2}.", expectedValue, expected, actual);
            }
            else if (expected < Constants<T>.MinValue.ToDouble())
            {
                var expectedValue = Constants<T>.MinValue.ToDouble();
                Execute.Assertion
                    .ForCondition(actual == expectedValue)
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:value} to be {0} (checked/clamped version of {1}){reason}, but it was {2}.", expectedValue, expected, actual);
            }
            else if (!Constants<T>.IsReal)
            {
                var expectedValue = Math.Truncate(expected);
                Execute.Assertion
                    .ForCondition(actual == expectedValue)
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:value} to be {0} (integral equivalent to {1}){reason}, but it was {2}.", expectedValue, expected, actual);
            }
            else
            {
                var expectedValue = Math.Round(expected, 2);
                var actualValue = Math.Round(actual, 2);
                Execute.Assertion
                    .ForCondition(actualValue == expectedValue)
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:value} to be {0}{reason}, but it was {1}.", expectedValue, actualValue);
            }
            return new AndConstraint<ComparableTypeAssertions<T>>(parent);
        }

        public static AndConstraint<ComparableTypeAssertions<T>> BeGreaterThan<T>(this ComparableTypeAssertions<T> parent, T expected, string because = "", params object[] becauseArgs) where T : struct, INumeric<T>
        {
            Execute.Assertion
                .ForCondition((T)parent.Subject > expected)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:value} to be greater than {0}{reason}, but it was {1}.", expected, parent.Subject);

            return new AndConstraint<ComparableTypeAssertions<T>>(parent);
        }

        public static AndConstraint<ComparableTypeAssertions<T>> BeGreaterThanOrEqualTo<T>(this ComparableTypeAssertions<T> parent, T expected, string because = "", params object[] becauseArgs) where T : struct, INumeric<T>
        {
            Execute.Assertion
                .ForCondition((T)parent.Subject >= expected)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:value} to be greater than or equal to {0}{reason}, but it was {1}.", expected, parent.Subject);

            return new AndConstraint<ComparableTypeAssertions<T>>(parent);
        }

        public static AndConstraint<ComparableTypeAssertions<T>> BeLessThan<T>(this ComparableTypeAssertions<T> parent, T expected, string because = "", params object[] becauseArgs) where T : struct, INumeric<T>
        {
            Execute.Assertion
                .ForCondition((T)parent.Subject < expected)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:value} to be less than {0}{reason}, but it was {1}.", expected, parent.Subject);

            return new AndConstraint<ComparableTypeAssertions<T>>(parent);
        }

        public static AndConstraint<ComparableTypeAssertions<T>> BeLessThanOrEqualTo<T>(this ComparableTypeAssertions<T> parent, T expected, string because = "", params object[] becauseArgs) where T : struct, INumeric<T>
        {
            Execute.Assertion
                .ForCondition((T)parent.Subject <= expected)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:value} to be less than or equal to {0}{reason}, but it was {1}.", expected, parent.Subject);

            return new AndConstraint<ComparableTypeAssertions<T>>(parent);
        }
    }
}
