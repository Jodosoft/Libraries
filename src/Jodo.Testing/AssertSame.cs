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
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;

namespace Jodo.Testing
{
    public static class AssertSame
    {
        /// <summary>
        /// Executes the specified functions and verifies that they either return equal results or
        /// throw the same type of exception.
        /// </summary>
        [AssertionMethod]
        public static void Outcome<TResult>(Func<TResult> expected, Func<TResult> subject, params Func<TResult>[] subjects)
        {
            Outcome(expected, subject);
            if (subjects != null)
            {
                foreach (Func<TResult> s in subjects)
                {
                    Outcome(expected, s);
                }
            }
        }

        /// <summary>
        /// Executes the specified functions and verifies that they either return equal results or
        /// throw the same type of exception.
        /// </summary>
        [AssertionMethod]
        public static void Outcome<TResult>(Func<TResult> expected, Func<TResult> subject)
        {
            TResult expectedResult;
            try
            {
                expectedResult = expected();

                TResult actualResult = subject.Should().NotThrow().Subject;

                if (!BothNaN(expectedResult, actualResult))
                {
                    actualResult.Should().Be(actualResult);
                }
            }
            catch (AssertionException)
            {
                throw;
            }
            catch (Exception exception)
            {
                subject.Should().Throw<Exception>($"expected threw \"{exception.Message}\"")
                    .Which.Should().BeOfType(exception.GetType());
            }
        }

        /// <summary>
        /// Executes the specified functions and verifies that they return equal results.
        /// </summary>
        [AssertionMethod]
        public static void Result<TResult>(Func<TResult> expected, Func<TResult> subject, params Func<TResult>[] subjects)
        {
            Result(expected, subject);
            if (subjects != null)
            {
                foreach (Func<TResult> s in subjects)
                {
                    Result(expected, s);
                }
            }
        }

        /// <summary>
        /// Executes the specified functions and verifies that they return equal results.
        /// </summary>
        [AssertionMethod]
        public static void Result<TResult>(Func<TResult> expected, Func<TResult> subject)
        {
            TResult expectedResult = expected();
            TResult actualResult = subject.Should().NotThrow().Subject;

            if (!BothNaN(expectedResult, actualResult))
            {
                actualResult.Should().Be(actualResult);
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
    }
}
