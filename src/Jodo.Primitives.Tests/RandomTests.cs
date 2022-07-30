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
using System.Linq;
using FluentAssertions;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Primitives.Tests
{
    public abstract class RandomTests<T> : GlobalFixtureBase where T : struct, IProvider<IRandom<T>>, IComparable<T>
    {
        [Test, Repeat(RandomVariations)]
        public void NextRandomizable_WithEqualBounds_ProducesSameResult()
        {
            //arrange
            T bound = Random.NextRandomizable<T>();

            //act
            T result = Random.NextRandomizable(bound, bound);

            //assert
            result.Should().Be(bound);
        }

        [Test, Repeat(RandomVariations)]
        public void NextRandomizable_WithRandomBounds_IsWithinBounds()
        {
            //arrange
            T bound1 = Random.NextRandomizable<T>();
            T bound2 = Random.NextRandomizable<T>();

            //act
            T result = Random.NextRandomizable(bound1, bound2);

            //assert
            if (bound1.CompareTo(bound2) <= 0)
            {
                result.Should().BeGreaterThanOrEqualTo(bound1);
                result.Should().BeLessThanOrEqualTo(bound2);
            }
            else
            {
                result.Should().BeGreaterThanOrEqualTo(bound2);
                result.Should().BeLessThanOrEqualTo(bound1);
            }
        }

        [Test, Repeat(RandomVariations)]
        public void NextRandomizable_ProducesDifferentResults()
        {
            //arrange
            T[] results = new T[10];

            //act
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = Random.NextRandomizable<T>();
            }

            //assert
            results.Distinct().Should().HaveCountGreaterThan(1);
        }

        [Test, Repeat(RandomVariations)]
        public void NextRandomizable_WithRandomBounds_ProducesDifferentResults()
        {
            //arrange
            T[] results = new T[10];

            //act
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = Random.NextRandomizable(Random.NextRandomizable<T>(), Random.NextRandomizable<T>());
            }

            //assert
            results.Distinct().Should().HaveCountGreaterThan(1);
        }
    }
}
