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

using FluentAssertions;
using Jodo.Extensions.Primitives;
using NUnit.Framework;
using System;

namespace Jodo.Extensions.Numerics.Tests
{
    public static class BitConverterTests
    {
        public class Fix64 : Base<fix64> { }
        public class UFix64 : Base<ufix64> { }
        public class XByte : Base<xbyte> { }
        public class XDecimal : Base<xdecimal> { }
        public class XDouble : Base<xdouble> { }
        public class XFloat : Base<xfloat> { }
        public class XInt : Base<xint> { }
        public class XLong : Base<xlong> { }
        public class XSByte : Base<xsbyte> { }
        public class XShort : Base<xshort> { }
        public class XUInt : Base<xuint> { }
        public class XULong : Base<xushort> { }
        public class XUShort : Base<xushort> { }

        public abstract class Base<N> : Primitives.Tests.BitConverterTests.Base<N> where N : struct, INumeric<N>
        {
            [Test, Repeat(RandomVariations)]
            public void GetBytes_RandomSmallValue_SameAsOriginal()
            {
                //arrange
                var input = Random.NextNumeric(Numeric<N>.MinUnit, Numeric<N>.MaxUnit);

                //act
                var result = BitConverter<N>.FromBytes(BitConverter<N>.GetBytes(input));

                //assert
                result.Should().Be(input);
            }

            [Test]
            public void GetBytes_MaxValueRoundTrip_SameAsOriginal()
            {
                //arrange
                var input = Numeric<N>.MaxValue;

                //act
                var result = BitConverter<N>.FromBytes(BitConverter<N>.GetBytes(input));

                //assert
                result.Should().Be(input);
            }

            [Test]
            public void GetBytes_MinValueRoundTrip_SameAsOriginal()
            {
                //arrange
                var input = Numeric<N>.MinValue;

                //act
                var result = BitConverter<N>.FromBytes(BitConverter<N>.GetBytes(input));

                //assert
                result.Should().Be(input);
            }

            [Test]
            public void GetBytes_EpsilonRoundTrip_SameAsOriginal()
            {
                //arrange
                var input = Numeric<N>.Epsilon;

                //act
                var result = BitConverter<N>.FromBytes(BitConverter<N>.GetBytes(input));

                //assert
                result.Should().Be(input);
            }
        }
    }
}
