﻿// Copyright (c) 2023 Joe Lawry-Short
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

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public abstract class ObjectTestBase<T> : GlobalFixtureBase where T : struct, IProvider<IVariantRandom<T>>
    {
        [Test, Repeat(RandomVariations)]
        public void Equals_Null_ReturnsFalse()
        {
            //arrange
            T input = Random.NextVariant<T>(Variants.NonError);

            //act
            bool result = input.Equals(null);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void Equals_DifferentType_ReturnsFalse()
        {
            //arrange
            T input = Random.NextVariant<T>(Variants.NonError);

            //act
            bool result = input.Equals(new Stopwatch());

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        [SuppressMessage("csharpsquid", "S1764:Identical expressions should not be used on both sides of operators.", Justification = "Used intentionally for this test.")]
        public void Equals_Itself_ReturnsTrue()
        {
            //arrange
            T input = Random.NextVariant<T>(Variants.NonError);

            //act
            bool result = input.Equals(input);

            //assert
            result.Should().BeTrue();
        }

        [Test, Repeat(RandomVariations)]
        public void Equals_Other_ReverseIsSame()
        {
            //arrange
            T input1 = Random.NextVariant<T>(Variants.NonError);
            T input2 = Random.NextVariant<T>(Variants.NonError);

            //act
            bool result1 = input1.Equals(input2);
            bool result2 = input2.Equals(input1);

            //assert
            result1.Should().Be(result2);
        }

        [Test, Repeat(RandomVariations)]
        public void GetHashCode_SameObject_ReturnsSameValue()
        {
            //arrange
            T input = Random.NextVariant<T>();
            int[] results = new int[100];

            //act
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = input.GetHashCode();
            }

            //assert
            results.Distinct().Should().HaveCount(1);
        }

        [Test, Repeat(RandomVariations)]
        public void GetHashCode_RandomInputs_ReturnsDifferentValues()
        {
            //arrange
            int[] results = new int[100];

            //act
            for (int i = 0; i < results.Length; i++)
            {
                T input = Random.NextVariant<T>();

                results[i] = input.GetHashCode();
            }

            //assert
            results.Distinct().Should().HaveCountGreaterThan(1);
        }

        [Test, Repeat(RandomVariations)]
        public void ToString_MultipleInvocations_ReturnsSameValue()
        {
            //arrange
            T input = Random.NextVariant<T>();
            string[] results = new string[100];

            //act
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = input.ToString();
            }

            //assert
            results.Distinct().Should().HaveCount(1);
        }

        [Test, Repeat(RandomVariations)]
        public void ToString_RandomInputs_ReturnsDifferentValues()
        {
            //arrange
            string[] results = new string[100];

            //act
            for (int i = 0; i < results.Length; i++)
            {
                T input = Random.NextVariant<T>();

                results[i] = input.ToString();
            }

            //assert
            results.Distinct().Should().HaveCountGreaterThan(1);
        }

        [Test, Repeat(RandomVariations)]
        public void GetHashCode_WhenEqualsTrue_ReturnsSameValue()
        {
            //arrange
            T input1 = Random.NextVariant<T>(Variants.NonError);
            T input2 = Random.NextVariant<T>(Variants.NonError);

            if (input1.Equals(input2))
            {
                //act
                int result1 = input1.GetHashCode();
                int result2 = input2.GetHashCode();

                //assert
                result1.Should().Be(result2);
            }
        }

        [Test, Repeat(RandomVariations)]
        public void RuntimeHelpersGetHashCode_SameValue_SameResult()
        {
            //arrange
            object input = Random.NextVariant<T>();

            //act
            int result1 = RuntimeHelpers.GetHashCode(input);
            int result2 = RuntimeHelpers.GetHashCode(input);

            //assert
            result1.Should().Be(result2);
        }
    }
}
