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
using System.Globalization;

namespace Jodo.Extensions.Numerics.Tests
{
    public static class ConvertTests
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
        public class XULong : Base<xulong> { }
        public class XUShort : Base<xushort> { }

        public abstract class Base<N> : NumericTestBase<N> where N : struct, INumeric<N>
        {
            [Test, Repeat(RandomVariations)]
            public void ToBoolean_RoundTrip_SameValue()
            {
                //arrange
                var input = Random.NextBoolean();

                //act
                var result = Convert<N>.ToBoolean(Convert<N>.ToValue(input));

                //assert
                result.Should().Be(input);
            }
            [Test, Repeat(RandomVariations)]
            public void ToByte_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric(
                    Clamp<N>.ToValue(byte.MinValue), Clamp<N>.ToValue(byte.MaxValue)));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToByte(input));

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void ToDecimal_SmallValueRoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Round(Random.NextNumeric(Clamp<N>.ToValue(-10M), Clamp<N>.ToValue(10M)), 2);

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToDecimal(input));

                //assert
                result.Should().BeApproximately(input);
            }

            [Test, Repeat(RandomVariations)]
            public void ToDouble_SmallValueRoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Round(Random.NextNumeric(Clamp<N>.ToValue(-10.0), Clamp<N>.ToValue(10.0)), 2);

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToDouble(input));

                //assert
                result.Should().BeApproximately(input);
            }

            [Test, Repeat(RandomVariations)]
            public void ToInt16_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric(
                    Clamp<N>.ToValue(short.MinValue), Clamp<N>.ToValue(short.MaxValue)));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToInt16(input));

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void ToInt32_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric(
                    Clamp<N>.ToValue(int.MinValue), Clamp<N>.ToValue(int.MaxValue)));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToInt32(input));

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void ToInt64_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric(
                    Clamp<N>.ToValue(long.MinValue), Clamp<N>.ToValue(long.MaxValue)));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToInt64(input));

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void ToSByte_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric(
                    Clamp<N>.ToValue(sbyte.MinValue), Clamp<N>.ToValue(sbyte.MaxValue)));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToSByte(input));

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void ToSingle_SmallValueRoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Round(Random.NextNumeric(Clamp<N>.ToValue(-10f), Clamp<N>.ToValue(10f)), 2);

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToSingle(input));

                //assert
                result.Should().BeApproximately(input);
            }

            [Test, Repeat(RandomVariations)]
            public void ToUInt16_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric(
                    Clamp<N>.ToValue(ushort.MinValue), Clamp<N>.ToValue(ushort.MaxValue)));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToUInt16(input));

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void ToUInt32_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric(
                    Clamp<N>.ToValue(uint.MinValue), Clamp<N>.ToValue(uint.MaxValue)));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToUInt32(input));

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void ToUInt64_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric(
                    Clamp<N>.ToValue(ulong.MinValue), Clamp<N>.ToValue(ulong.MaxValue)));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToUInt64(input));

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void ToString1_Random_SameAsObjectToString()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result = Convert<N>.ToString(input);

                //assert
                result.Should().Be(input.ToString());
            }

            [Test, Repeat(RandomVariations)]
            public void ToString1_RandomWithFormatProvider_SameAsNumericToString()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result = Convert<N>.ToString(input, NumberFormatInfo.InvariantInfo);

                //assert
                result.Should().Be(input.ToString(NumberFormatInfo.InvariantInfo));
            }
        }
    }
}
