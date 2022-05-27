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
    public static class StringParserTests
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
            [Test, Repeat(RandomVariations)]
            public void Parse1_RoundTripSmallValue_CorrectResult()
            {
                //arrange
                var input = NextLowPrecision();

                //act
                var result = StringParser<N>.Parse(input.ToString());

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Parse1_RoundTripFormat_CorrectResult()
            {
                //arrange
                var input = NextLowPrecision();
                var format = "G17";

                //act
                var result = StringParser<N>.Parse(input.ToString(format));

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Parse1_RoundTripFormatWithProvider_CorrectResult()
            {
                //arrange
                var input = NextLowPrecision();
                var format = "G17";

                //act
                var result = StringParser<N>.Parse(input.ToString(format, NumberFormatInfo.InvariantInfo));

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Parse2_RoundTripFormatWithProvider_CorrectResult()
            {
                //arrange
                var input = NextLowPrecision();
                var format = "G17";
                var provider = NumberFormatInfo.InvariantInfo;
                var numberStyles = NumberStyles.Any;

                //act
                var result = StringParser<N>.Parse(input.ToString(format, provider), numberStyles, provider);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Parse2_SmallIntegralHexString_CorrectResult()
            {
                //arrange
                OnlyApplicableTo.Integral();
                var input = Random.Next(0, 128);
                var hexString = input.ToString("X");

                //act
                var result = StringParser<N>.Parse(hexString, NumberStyles.HexNumber, NumberFormatInfo.InvariantInfo);

                //assert
                result.Should().Be(Convert<N>.ToValue(input));
            }
        }
    }
}
