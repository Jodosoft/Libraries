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
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public static class Vector3Tests
    {
        public sealed class FixedPointBitConverter : Primitives.Tests.BitConvertTestsBase<Vector3<Fix64>> { }
        public sealed class FixedPointGeneralTests : GeneralTests<Fix64> { }
        public sealed class FixedPointObjectTests : Primitives.Tests.ObjectTestsBase<Vector3<Fix64>> { }
        public sealed class FixedPointSerializableTests : Primitives.Tests.SerializableTestsBase<Vector3<Fix64>> { }

        public sealed class FloatingPointBitConverter : Primitives.Tests.BitConvertTestsBase<Vector3<SingleN>> { }
        public sealed class FloatingPointGeneralTests : GeneralTests<SingleN> { }
        public sealed class FloatingPointObjectTests : Primitives.Tests.ObjectTestsBase<Vector3<SingleN>> { }
        public sealed class FloatingPointSerializableTests : Primitives.Tests.SerializableTestsBase<Vector3<SingleN>> { }

        public sealed class UnsignedIntegralBitConverter : Primitives.Tests.BitConvertTestsBase<Vector3<ByteN>> { }
        public sealed class UnsignedIntegralGeneralTests : GeneralTests<ByteN> { }
        public sealed class UnsignedIntegralObjectTests : Primitives.Tests.ObjectTestsBase<Vector3<ByteN>> { }
        public sealed class UnsignedIntegralSerializableTests : Primitives.Tests.SerializableTestsBase<Vector3<ByteN>> { }
        public sealed class UnsignedIntegralStringParser : Primitives.Tests.StringParserTestsBase<Vector3<ByteN>> { }

        public abstract class GeneralTests<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [Test, Repeat(RandomVariations)]
            public void Ctor_RandomValues_CorrectResult()
            {
                //arrange
                TNumeric x = Random.NextNumeric<TNumeric>();
                TNumeric y = Random.NextNumeric<TNumeric>();
                TNumeric z = Random.NextNumeric<TNumeric>();

                //act
                Vector3<TNumeric> result = new Vector3<TNumeric>(x, y, z);

                //assert
                result.X.Should().Be(x);
                result.Y.Should().Be(y);
                result.Z.Should().Be(z);
            }

            [Test, Repeat(RandomVariations)]
            public void Random_WithinBounds_CorrectResult()
            {
                //arrange
                Vector3<TNumeric> bound1 = Random.NextRandomizable<Vector3<TNumeric>>();
                Vector3<TNumeric> bound2 = Random.NextRandomizable<Vector3<TNumeric>>();

                //act
                Vector3<TNumeric> result = Random.NextRandomizable(bound1, bound2);

                //assert
                result.X.Should().BeInRange(MathN.Min(bound1.X, bound2.X), MathN.Max(bound1.X, bound2.X));
                result.Y.Should().BeInRange(MathN.Min(bound1.Y, bound2.Y), MathN.Max(bound1.Y, bound2.Y));
                result.Z.Should().BeInRange(MathN.Min(bound1.Z, bound2.Z), MathN.Max(bound1.Z, bound2.Z));
            }
        }
    }
}
