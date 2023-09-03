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
using System.Linq;
using FluentAssertions;
using Jodosoft.Primitives;
using NUnit.Framework;

namespace Jodosoft.Testing
{
    /// <summary>
    /// Provides common test methods for structs that verify fundamental methods such
    /// as <see cref="object.Equals(object)"/> and <see cref="object.GetHashCode()"/>.
    /// </summary>
    /// <typeparam name="T">The type of struct.</typeparam>
    public abstract class FormattableTestBase<T> : GlobalFixtureBase where T : struct, IFormattable, IProvider<IVariantRandom<T>>
    {
        [Test, Repeat(RandomVariations)]
        public void ToString_MultipleInvocationsWithNullFormat_ReturnsSameValue()
        {
            //arrange
            T input = Random.NextVariant<T>();

            string[] results = new string[100];

            //act
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = input.ToString(null, null);
            }

            //assert
            results.Distinct().Should().HaveCount(1);
        }

        [Test, Repeat(RandomVariations)]
        public void ToString_RandomInputsWithNullFormat_ReturnsDifferentValues()
        {
            //arrange
            string[] results = new string[100];

            //act
            for (int i = 0; i < results.Length; i++)
            {
                T input = Random.NextVariant<T>();

                results[i] = input.ToString(null, null);
            }

            //assert
            results.Distinct().Should().HaveCountGreaterThan(1);
        }

        [Test, Repeat(RandomVariations)]
        public void ToString_RandomInputWithNullFormat_SameAsToString()
        {
            //arrange
            T input = Random.NextVariant<T>();

            //act
            string result = input.ToString(null, null);

            //assert
            result.Should().Be(result.ToString());
        }

        [Test, Repeat(RandomVariations)]
        public void ToString_RandomInputWithCurrentCulture_SameAsToString()
        {
            //arrange
            T input = Random.NextVariant<T>();

            //act
            string result = input.ToString(null, CultureInfo.CurrentCulture);

            //assert
            result.Should().Be(result.ToString());
        }
    }
}
