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
using Jodo.Extensions.Testing;
using NUnit.Framework;

namespace Jodo.Extensions.Numerics.Tests
{
    public static class Vector3Tests
    {
        public sealed class FixedPoint : General<fix64> { }
        public sealed class FloatingPoint : General<xfloat> { }
        public sealed class UnsignedIntegral : General<xbyte> { }

        public abstract class General<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            public sealed class BitConverter : Primitives.Tests.BitConverterTests<Unit<N>> { }
            public sealed class StringParser : Primitives.Tests.StringParserTests<Unit<N>> { }

            [Test]
            public void Ctor_RandomValues_CorrectResult()
            {
                //arrange
                N x = Random.NextNumeric<N>();
                N y = Random.NextNumeric<N>();
                N z = Random.NextNumeric<N>();

                //act
                Vector3<N> result = new Vector3<N>(x, y, z);

                //assert
                result.X.Should().Be(x);
                result.Y.Should().Be(y);
                result.Z.Should().Be(z);
            }

            [Test]
            public void Random_WithinBounds_CorrectResult()
            {
                //arrange
                Vector3<N> bound1 = Random.NextRandomizable<Vector3<N>>();
                Vector3<N> bound2 = Random.NextRandomizable<Vector3<N>>();
                Vector3<N> bound3 = Random.NextRandomizable<Vector3<N>>();

                //act
                Vector3<N> result = Random.NextRandomizable(bound1, bound2);

                //assert
                result.X.Should().BeInRange(Math<N>.Min(bound1.X, bound2.X), Math<N>.Max(bound1.X, bound2.X));
                result.Y.Should().BeInRange(Math<N>.Min(bound1.Y, bound2.Y), Math<N>.Max(bound1.Y, bound2.Y));
                result.Z.Should().BeInRange(Math<N>.Min(bound1.Z, bound2.Z), Math<N>.Max(bound1.Z, bound2.Z));
            }
        }
    }
}
