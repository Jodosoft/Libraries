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
using Jodo.Extensions.Testing;
using System;

namespace Jodo.Extensions.Numerics.Tests
{
    public static class ConvertTests
    {
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
            [TestRepeatedly]
            public void Boolean_RoundTrip_SameValue()
            {
                //arrange
                var input = Random.NextBoolean();

                //act
                var result = Convert<N>.ToBoolean(Convert<N>.ToValue(input));

                //assert
                result.Should().Be(input);
            }

            [TestRepeatedly]
            public void ToByte_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric<N>(byte.MinValue, byte.MaxValue));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToByte(input));

                //assert
                result.Should().Be(input);
            }

            [TestRepeatedly]
            public void ToChar_IntegralRoundTrip_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = Random.NextNumeric<N>(char.MinValue, char.MaxValue);

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToChar(input));

                //assert
                result.Should().Be(input);
            }

            [TestRepeatedly]
            public void ToChar_Real_Throws()
            {
                //arrange
                RealOnly();
                var input = Random.NextNumeric<N>();

                //act
                var action = new Action(() => Convert<N>.ToChar(input));

                //assert
                action.Should().Throw<InvalidCastException>();
            }

            public void Decimal_RoundTrip_SameValue()
            {
                //arrange
                var input = Random.NextNumeric<N>(-MaxTestableReal, MaxTestableReal);
                if (!Math<N>.IsReal) input = Math<N>.Truncate(input);

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToDecimal(input));

                //assert
                result.Should().BeApproximately(input);
            }

            public void Double_RoundTrip_SameValue()
            {
                //arrange
                var input = Random.NextNumeric<N>(-MaxTestableReal, MaxTestableReal);
                if (!Math<N>.IsReal) input = Math<N>.Truncate(input);

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToDouble(input));

                //assert
                result.Should().BeApproximately(input);
            }

            [TestRepeatedly]
            public void Int16_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric<N>(short.MinValue, short.MaxValue));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToInt16(input));

                //assert
                result.Should().Be(input);
            }

            [TestRepeatedly]
            public void Int32_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric<N>(int.MinValue, int.MaxValue));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToInt32(input));

                //assert
                result.Should().Be(input);
            }

            [TestRepeatedly]
            public void Int64_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric<N>(long.MinValue, long.MaxValue));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToInt64(input));

                //assert
                result.Should().Be(input);
            }

            [TestRepeatedly]
            public void SByte_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric<N>(sbyte.MinValue, sbyte.MaxValue));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToSByte(input));

                //assert
                result.Should().Be(input);
            }

            [TestRepeatedly]
            public void Single_RoundTrip_SameValue()
            {
                //arrange
                var input = Random.NextNumeric<N>(-MaxTestableReal, MaxTestableReal);
                if (!Math<N>.IsReal) input = Math<N>.Truncate(input);

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToSingle(input));

                //assert
                result.Should().BeApproximately(input);
            }

            [TestRepeatedly]
            public void UInt16_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric<N>(ushort.MinValue, ushort.MaxValue));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToUInt16(input));

                //assert
                result.Should().Be(input);
            }

            [TestRepeatedly]
            public void UInt32_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric<N>(uint.MinValue, uint.MaxValue));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToUInt32(input));

                //assert
                result.Should().Be(input);
            }

            [TestRepeatedly]
            public void UInt64_RoundTrip_SameValue()
            {
                //arrange
                var input = Math<N>.Truncate(Random.NextNumeric<N>(ulong.MinValue, ulong.MaxValue));

                //act
                var result = Convert<N>.ToValue(Convert<N>.ToUInt64(input));

                //assert
                result.Should().Be(input);
            }
        }
    }
}
