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
        public static AndConstraint<ComparableTypeAssertions<T>> BeNumericEquivalentTo<T>(this ComparableTypeAssertions<T> parent, double expected, string because = "", params object[] becauseArgs) where T : struct, INumeric<T>
        {
            var actual = Math<T>.ToDouble((T)parent.Subject, 0);
            if (!Math<T>.IsReal)
            {
                var expectedValue = Math.Truncate(expected);
                Execute.Assertion
                    .ForCondition(actual == expectedValue)
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:value} to be {0} (integral equivalent to {1}){reason}, but it was {2}.", expectedValue, expected, actual);
            }
            else if (double.IsFinite(expected))
            {
                var expectedValue = Math.Round(expected, 2);
                var actualValue = Math.Round(actual, 2);
                Execute.Assertion
                    .ForCondition(actualValue == expectedValue)
                    .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:value} to be {0}{reason}, but it was {1}.", expectedValue, actualValue);
            }
            else
            {
                Execute.Assertion
                 .ForCondition(
                     (double.IsNaN(expected) && double.IsNaN(actual)) ||
                     (double.IsPositiveInfinity(expected) && double.IsPositiveInfinity(actual)) ||
                     (double.IsNegativeInfinity(expected) && double.IsNegativeInfinity(actual)))
                 .BecauseOf(because, becauseArgs)
                    .FailWith("Expected {context:value} to be {0}{reason}, but it was {1}.", expected, actual);
            }
            return new AndConstraint<ComparableTypeAssertions<T>>(parent);
        }
    }
}
