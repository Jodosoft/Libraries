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
    public static class NumericFunctionsTests
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
            [Test]
            public void Epsilon_LessThanOrEqualToOne()
            {
                Numeric<N>.Epsilon.Should().BeLessThanOrEqualTo(Numeric<N>.One);
            }

            [Test]
            public void Epsilon_Integral_IsOne()
            {
                OnlyApplicableTo.Integral();
                Convert<N>.ToDouble(Numeric<N>.Epsilon).Should().Be(1);
            }

            [Test]
            public void Epsilon_Real_GreaterThanZero()
            {
                OnlyApplicableTo.Real();
                Convert<N>.ToDouble(Numeric<N>.Epsilon).Should().BeGreaterThan(0);
            }

            [Test]
            public void Epsilon_Real_LessThanOne()
            {
                OnlyApplicableTo.Real();
                Convert<N>.ToDouble(Numeric<N>.Epsilon).Should().BeLessThan(1);
            }

            [Test]
            public void Epsilon_Real_ApproximatelyZero()
            {
                OnlyApplicableTo.Real();
                Convert<N>.ToDouble(Numeric<N>.Epsilon).Should().BeApproximately(0, 0.0001);
            }

            [Test]
            public void MaxUnit_LessThanMaxValue()
            {
                Numeric<N>.MaxUnit.Should().BeLessThan(Numeric<N>.MaxValue);
            }

            [Test]
            public void MaxUnit_IsOne()
            {
                Convert<N>.ToDouble(Numeric<N>.MaxUnit).Should().Be(1);
            }

            [Test]
            public void MinUnit_LessThanMaxUnit()
            {
                Numeric<N>.MinUnit.Should().BeLessThan(Numeric<N>.MaxUnit);
            }

            [Test]
            public void MinUnit_Unsigned_IsZero()
            {
                OnlyApplicableTo.Unsigned();
                Numeric<N>.MinUnit.Should().Be(Numeric<N>.Zero);
            }

            [Test]
            public void MinUnit_Signed_IsMinusOne()
            {
                OnlyApplicableTo.Signed();
                Convert<N>.ToDouble(Numeric<N>.MinUnit).Should().Be(-1);
            }

            [Test]
            public void MinValue_Unsigned_IsZero()
            {
                OnlyApplicableTo.Unsigned();
                Numeric<N>.MinValue.Should().Be(Numeric<N>.Zero);
            }

            [Test]
            public void MinValue_Signed_IsNegative()
            {
                OnlyApplicableTo.Signed();
                Convert<N>.ToDouble(Numeric<N>.MinValue).Should().BeLessThanOrEqualTo(sbyte.MinValue);
            }

            [Test]
            public void MaxValue_IsPositive()
            {
                Convert<N>.ToDouble(Numeric<N>.MaxValue).Should().BeGreaterThanOrEqualTo(sbyte.MaxValue);
            }

            [Test]
            public void One_IsOne()
            {
                Convert<N>.ToDouble(Numeric<N>.One).Should().Be(1);
            }

            [Test]
            public void Ten_IsTen()
            {
                Convert<N>.ToDouble(Numeric<N>.Ten).Should().Be(10);
            }

            [Test]
            public void Two_IsTwo()
            {
                Convert<N>.ToDouble(Numeric<N>.Two).Should().Be(2);
            }

            [Test]
            public void Zero_LessThanEpsilon()
            {
                Numeric<N>.Zero.Should().BeLessThan(Numeric<N>.Epsilon);
            }

            [Test]
            public void Zero_IsZero()
            {
                Convert<N>.ToDouble(Numeric<N>.Zero).Should().Be(0);
            }

            [Test]
            public void IsFinite_RandomIntegral_AlwaysTrue()
            {
                //arrange
                OnlyApplicableTo.Integral();
                var input = Random.NextNumeric<N>();

                //act
                var result = Numeric<N>.IsFinite(input);

                //assert
                result.Should().BeTrue();
            }

            [Test]
            public void IsInfinity_RandomIntegral_AlwaysFalse()
            {
                //arrange
                OnlyApplicableTo.Integral();
                var input = Random.NextNumeric<N>();

                //act
                var result = Numeric<N>.IsInfinity(input);

                //assert
                result.Should().BeFalse();
            }

            [Test]
            public void IsNaN_RandomIntegral_AlwaysFalse()
            {
                //arrange
                OnlyApplicableTo.Integral();
                var input = Random.NextNumeric<N>();

                //act
                var result = Numeric<N>.IsNaN(input);

                //assert
                result.Should().BeFalse();
            }

            [Test]
            public void IsNaN_RandomUnsigned_AlwaysFalse()
            {
                //arrange
                OnlyApplicableTo.Unsigned();
                var input = Random.NextNumeric<N>();

                //act
                var result = Numeric<N>.IsNegative(input);

                //assert
                result.Should().BeFalse();
            }

            [Test]
            public void IsNegativeInfinity_RandomIntegral_AlwaysFalse()
            {
                //arrange
                OnlyApplicableTo.Integral();
                var input = Random.NextNumeric<N>();

                //act
                var result = Numeric<N>.IsNegativeInfinity(input);

                //assert
                result.Should().BeFalse();
            }

            [Test]
            public void IsNormal_RandomIntegral_AlwaysFalse()
            {
                //arrange
                OnlyApplicableTo.Integral();
                var input = Random.NextNumeric<N>();

                //act
                var result = Numeric<N>.IsNormal(input);

                //assert
                result.Should().BeFalse();
            }

            [Test]
            public void IsPositiveInfinity_RandomIntegral_AlwaysFalse()
            {
                //arrange
                OnlyApplicableTo.Integral();
                var input = Random.NextNumeric<N>();

                //act
                var result = Numeric<N>.IsPositiveInfinity(input);

                //assert
                result.Should().BeFalse();
            }

            [Test]
            public void IsSubnormal_RandomIntegral_AlwaysFalse()
            {
                //arrange
                OnlyApplicableTo.Integral();
                var input = Random.NextNumeric<N>();

                //act
                var result = Numeric<N>.IsSubnormal(input);

                //assert
                result.Should().BeFalse();
            }
        }
    }
}
