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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Jodo.Extensions.Numerics.Tests
{
    public static class NumericTests
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
        public class XULong : Base<xushort> { }
        public class XUShort : Base<xushort> { }

        public abstract class Base<N> : NumericTestBase<N> where N : struct, INumeric<N>
        {
            [Test, Repeat(10)]
            public void Equals1_RandomValues_SameAsSystem()
            {
                //arrange
                var input1 = Random.NextByte(0, 2);
                var input2 = Random.NextByte(0, 2);
                var sut1 = Convert<N>.ToValue(input1);
                var sut2 = Convert<N>.ToValue(input2);

                //act
                var result = sut1.Equals(sut2);

                //assert
                result.Should().Be(input1.Equals(input2));
            }

            [Test, Repeat(10)]
            public void Equals2_RandomValues_SameAsSystem()
            {
                //arrange
                var input1 = Random.NextByte(0, 2);
                var input2 = Random.NextByte(0, 2);
                var sut1 = Convert<N>.ToValue(input1);
                var sut2 = Convert<N>.ToValue(input2);

                //act
                var result = sut1.Equals((object)sut2);

                //assert
                result.Should().Be(input1.Equals(input2));
            }

            [Test, Repeat(10)]
            public void CompareTo1_RandomValues_SameSignAsSystem()
            {
                //arrange
                var input1 = Random.NextByte(0, 2);
                var input2 = Random.NextByte(0, 2);
                var sut1 = Convert<N>.ToValue(input1);
                var sut2 = Convert<N>.ToValue(input2);

                //act
                var result = Math.Sign(sut1.CompareTo(sut2));

                //assert
                result.Should().Be(Math.Sign(input1.CompareTo(input2)));
            }

            [Test, Repeat(10)]
            public void CompareTo1_NullNullable_Returns1()
            {
                //arrange
                var input = Random.NextNumeric<N>();
                var other = (N?)null;

                //act
                var result = input.CompareTo(other);

                //assert
                result.Should().Be(1);
            }

            [Test, Repeat(10)]
            public void CompareTo1_DifferentType_Returns1()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result = input.CompareTo(this);

                //assert
                result.Should().Be(1);
            }

            [Test, Repeat(10)]
            public void GetHashCode_SameValue_SameResult()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result1 = input.GetHashCode();
                var result2 = input.GetHashCode();

                //assert
                result1.Should().Be(result2);
            }

            [Test, Repeat(10)]
            public void GetHashCode_EqualValues_SameResult()
            {
                //arrange
                var input = Random.NextByte(0, 127);
                var sut1 = Convert<N>.ToValue(input);
                var sut2 = Convert<N>.ToValue(input);

                //act
                var result1 = sut1.GetHashCode();
                var result2 = sut2.GetHashCode();

                //assert
                result1.Should().Be(result2);
            }

            [Test, Repeat(10)]
            public void GetHashCode_DifferentSmallValues_DifferentResult()
            {
                //arrange
                var input1 = Random.NextByte(0, 127);
                byte input2;
                do { input2 = Random.NextByte(0, 127); ; } while (input2 == input1);
                var sut1 = Convert<N>.ToValue(input1);
                var sut2 = Convert<N>.ToValue(input2);

                //act
                var result1 = sut1.GetHashCode();
                var result2 = sut2.GetHashCode();

                //assert
                result1.Should().NotBe(result2);
            }

            [Test, Repeat(10)]
            public void Serialize_RoundTrip_SameAsOriginal()
            {
                //arrange
                var input = Random.NextNumeric<N>();
                var formatter = new BinaryFormatter();

                //act
                using var stream = new MemoryStream();
                formatter.Serialize(stream, input);
                stream.Position = 0;
                var result = (N)formatter.Deserialize(stream);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(10)]
            public void ToSingle_RandomValues_SameAsConvert()
            {
                //arrange
                var input = Random.NextNumeric<N>(-MaxTestableReal, MaxTestableReal);

                //act
                var result = input.ToSingle();

                //assert
                result.Should().Be(Convert<N>.ToSingle(input));
            }

            [Test, Repeat(10)]
            public void ToDouble_RandomValues_SameAsConvert()
            {
                //arrange
                var input = Random.NextNumeric<N>(-MaxTestableReal, MaxTestableReal);

                //act
                var result = input.ToDouble();

                //assert
                result.Should().Be(Convert<N>.ToDouble(input));
            }
        }
    }
}
