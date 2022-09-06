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
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

namespace Jodo.Testing
{
    public static class AssertSame
    {
        /// <summary>
        /// Executes the specified functions exactly once and asserts that they all returned equal results
        /// (using <see cref="object.Equals(object)"/>) or all threw the same type of exception.
        /// </summary>
        [AssertionMethod]
        public static void Outcome<TResult>(Func<TResult> expected, Func<TResult> actual, params Func<TResult>[] actuals)
        {
            (TResult Result, Exception Exception) expectedOutcome = GetOutcome(expected);

            List<(TResult Result, Exception Exception)> subjectOutcomes = new List<(TResult Result, Exception Exception)>
            {
                GetOutcome(actual)
            };
            if (actuals != null)
            {
                foreach (Func<TResult> s in actuals)
                {
                    subjectOutcomes.Add(GetOutcome(s));
                }
            }

            foreach ((TResult Result, Exception Exception) subjectOutcome in subjectOutcomes)
            {
                VerifyOutcomes(expectedOutcome, subjectOutcome);
            }
        }

        /// <summary>
        /// Asserts that the specified values are equal (using <see cref="object.Equals(object)"/>).
        /// </summary>
        [AssertionMethod]
        public static void Value<TResult>(TResult expectedValue, TResult actualValue, params TResult[] actualValues)
        {
            if (!BothNaN(expectedValue, actualValue))
            {
                actualValue.Should().Be(expectedValue);
            }
            foreach (TResult subjectResult in actualValues)
            {
                if (!BothNaN(expectedValue, subjectResult))
                {
                    subjectResult.Should().Be(expectedValue);
                }
            }
        }

        /// <summary>
        /// Executes the specified functions exactly once and asserts that they all returned equal results
        /// (using <see cref="object.Equals(object)"/>).
        /// </summary>
        [AssertionMethod]
        public static void Result<TResult>(Func<TResult> expected, Func<TResult> actual, params Func<TResult>[] actuals)
        {
            TResult expectedResult = expected.Should().NotThrow().Subject;
            List<TResult> subjectResults = new List<TResult>()
            {
                actual.Should().NotThrow().Subject
            };
            if (actuals != null)
            {
                foreach (Func<TResult> s in actuals)
                {
                    subjectResults.Add(s.Should().NotThrow().Subject);
                }
            }
            foreach (TResult subjectResult in subjectResults)
            {
                if (!BothNaN(expectedResult, subjectResult))
                {
                    subjectResult.Should().Be(expectedResult);
                }
            }
        }

        private static bool BothNaN<T>(T value1, T value2)
        {
            bool bothNaN =
                typeof(T).IsValueType &&
                value1.ToString() == CultureInfo.CurrentCulture.NumberFormat.NaNSymbol &&
                value2.ToString() == CultureInfo.CurrentCulture.NumberFormat.NaNSymbol;
            return bothNaN;
        }

        private static (TResult Result, Exception Exception) GetOutcome<TResult>(Func<TResult> function)
        {
            try
            {
                return (function(), null);
            }
            catch (Exception exception)
            {
                return (default, exception);
            }
        }

        private static void VerifyOutcomes<TResult>((TResult Result, Exception Exception) outcome1, (TResult Result, Exception Exception) outcome2)
        {
            Exception expectedException = outcome1.Exception ?? outcome2.Exception;

            if (expectedException != null)
            {
                if (outcome1.Exception == null || outcome2.Exception == null)
                {
                    Assert.Fail("Expected a <{0}> to be thrown but no exception was thrown.", expectedException.GetType().Name);
                }

                if (outcome1.Exception.GetType() != expectedException.GetType())
                {
                    Assert.Fail("Expected a <{0}> to be thrown but found <{1}>", expectedException.GetType().Name, outcome1.Exception.GetType().Name);
                }

                if (outcome2.Exception.GetType() != expectedException.GetType())
                {
                    Assert.Fail("Expected a <{0}> to be thrown but found <{1}>", expectedException.GetType().Name, outcome2.Exception.GetType().Name);
                }
            }

            if (!BothNaN(outcome1.Result, outcome2.Result))
            {
                outcome1.Result.Should().Be(outcome2.Result);
            }
        }
    }
}
