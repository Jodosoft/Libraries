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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Jodosoft.Testing
{
    /// <summary>
    /// Provides assertion methods for verifying that sets of operations return the same value or throw the same exception.
    /// </summary>
    public static class AssertSame
    {
        /// <summary>
        /// Executes all of the specified functions exactly once and asserts that they returned equal results
        /// (using <see cref="object.Equals(object)"/>) or that they threw the same type of exception.
        /// </summary>
        /// <typeparam name="TResult">The type of value returned by the specified functions.</typeparam>
        /// <param name="expected">A function that will be executed, and the outcome verified.</param>
        /// <param name="actual">Another function that will be executed, the outcome verified.</param>
        /// <param name="actuals">Further functions that will be executed, their outcomes verified.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="expected"/> or <paramref name="actual"/> are null.</exception>
        /// <exception cref="ArgumentException">If <paramref name="actuals"/> contains null elements.</exception>
        [AssertionMethod]
        public static void Outcome<TResult>(Func<TResult> expected, Func<TResult> actual, params Func<TResult>[] actuals)
        {
            Outcome(ValidateArguments(expected, actual, actuals));
        }

        /// <summary>
        /// Executes all of the specified functions exactly once and asserts that they returned equal results
        /// (using <see cref="object.Equals(object)"/>) or that they threw the same type of exception.
        /// </summary>
        /// <typeparam name="TResult">The type of value returned by the specified functions.</typeparam>
        /// <param name="functions">Functions that will be executed, their outcomes verified.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="functions"/> is null.</exception>
        /// <exception cref="ArgumentException">If <paramref name="functions"/> contains less than 2 elements or any null elements.</exception>
        [AssertionMethod]
        public static void Outcome<TResult>(IEnumerable<Func<TResult>> functions)
        {
            if (functions == null) throw new ArgumentNullException(nameof(functions));

            Func<TResult>[] functionsArray = functions.ToArray();

            if (functionsArray.Length < 2) throw new ArgumentException("Must provide at least 2 functions for comparison", nameof(functions));

            List<(TResult Result, Exception Exception)> outcomes = new List<(TResult Result, Exception Exception)>();

            foreach (Func<TResult> function in functionsArray)
            {
                if (function == null) throw new ArgumentException("Must not contain null elements", nameof(functions));

                outcomes.Add(GetOutcome(function));
            }

            for (int i = 1; i < outcomes.Count; i++)
            {
                VerifyOutcomes(outcomes[0], outcomes[i], i);
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
            Result(ValidateArguments(expected, actual, actuals));
        }

        /// <summary>
        /// Executes the specified functions exactly once and asserts that they all returned equal results
        /// (using <see cref="object.Equals(object)"/>).
        /// </summary>
        [AssertionMethod]
        public static void Result<TResult>(IEnumerable<Func<TResult>> functions)
        {
            if (functions == null) throw new ArgumentNullException(nameof(functions));

            Func<TResult>[] functionsArray = functions.ToArray();

            if (functionsArray.Length < 2) throw new ArgumentException("Must provide at least 2 functions for comparison", nameof(functions));

            List<TResult> results = new List<TResult>();

            foreach (Func<TResult> function in functionsArray)
            {
                if (function == null) throw new ArgumentException("Must not contain null elements", nameof(functions));

                results.Add(function.Should().NotThrow().Subject);
            }

            for (int i = 1; i < results.Count; i++)
            {
                VerifyResults(results[0], results[i], i);
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

        private static void VerifyOutcomes<TResult>((TResult Result, Exception Exception) outcome1, (TResult Result, Exception Exception) outcome2, int position)
        {
            Exception expectedException = outcome1.Exception;

            if (expectedException != null)
            {
                if (outcome1.Exception == null || outcome2.Exception == null)
                {
                    Assert.Fail("Expected a <{0}> to be thrown by function at position <{1}>, but no exception was thrown.",
                        expectedException.GetType().Name, position);
                }

                if (outcome1.Exception.GetType() != expectedException.GetType())
                {
                    Assert.Fail("Expected a <{0}> to be thrown by function at position <{1}> but found <{2}>",
                        expectedException.GetType().Name, position, outcome1.Exception.GetType().Name);
                }

                if (outcome2.Exception.GetType() != expectedException.GetType())
                {
                    Assert.Fail("Expected a <{0}> to be thrown by function at position <{1}> but found <{2}>",
                        expectedException.GetType().Name, position, outcome2.Exception.GetType().Name);
                }
            }

            VerifyResults(outcome1.Result, outcome2.Result, position);
        }

        private static void VerifyResults<TResult>(TResult value1, TResult value2, int position)
        {
            if (!BothNaN(value1, value2))
            {
                value2.Should().Be(value1, "the value returned by function at position <{0}> should match the value returned by the other functions", position);
            }
        }

        private static List<Func<TResult>> ValidateArguments<TResult>(Func<TResult> expected, Func<TResult> actual, Func<TResult>[] actuals)
        {
            if (expected == null) throw new ArgumentNullException(nameof(expected));
            if (actual == null) throw new ArgumentNullException(nameof(actual));

            List<Func<TResult>> functions = new List<Func<TResult>> { expected, actual };
            if (actuals != null)
            {
                foreach (Func<TResult> a in actuals)
                {
                    if (a == null) throw new ArgumentException("Must not contain null elements", nameof(actuals));
                    functions.Add(a);
                }
            }

            return functions;
        }
    }
}
