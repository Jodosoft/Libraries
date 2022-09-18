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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using AutoFixture;
using FluentAssertions;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    [SuppressMessage("Style", "IDE0004:Cast is redundant", Justification = "Necessary to be explicit in these tests.")]
    public class ConvertNTests : GlobalFixtureBase
    {
        private static MethodInfo[] GetMethodsWithConversionParameter()
        {
            MethodInfo[] methods = typeof(ConvertN)
                .GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(x => !x.ContainsGenericParameters && x.GetParameters().Any(p => p.ParameterType == typeof(Conversion)))
                .ToArray();

            if (methods.Length == 0) Assert.Fail();
            return methods;
        }

        [Test] public void DoubleToByteCast_NaN_SameAsSystem() => AssertSame.Outcome(() => unchecked((byte)double.NaN), () => ConvertN.ToByte(double.NaN, Conversion.Cast));
        [Test] public void DoubleToByteCast_NegativeInfinity_SameAsSystem() => AssertSame.Outcome(() => unchecked((byte)double.NegativeInfinity), () => ConvertN.ToByte(double.NegativeInfinity, Conversion.Cast));
        [Test] public void DoubleToByteCast_PositiveInfinity_SameAsSystem() => AssertSame.Outcome(() => unchecked((byte)double.PositiveInfinity), () => ConvertN.ToByte(double.PositiveInfinity, Conversion.Cast));
        [Test] public void DoubleToByteCastClamp_NaN_ReturnsZero() => ConvertN.ToByte(double.NaN, Conversion.CastClamp).Should().Be((byte)0);
        [Test] public void DoubleToByteCastClamp_NegativeInfinity_ReturnsMinValue() => ConvertN.ToByte(double.NegativeInfinity, Conversion.CastClamp).Should().Be(byte.MinValue);
        [Test] public void DoubleToByteCastClamp_PositiveInfinity_ReturnsMaxValue() => ConvertN.ToByte(double.PositiveInfinity, Conversion.CastClamp).Should().Be(byte.MaxValue);
        [Test] public void DoubleToByteClamp_NaN_ReturnsZero() => ConvertN.ToByte(double.NaN, Conversion.Clamp).Should().Be((byte)0);
        [Test] public void DoubleToByteClamp_NegativeInfinity_ReturnsMinValue() => ConvertN.ToByte(double.NegativeInfinity, Conversion.Clamp).Should().Be(byte.MinValue);
        [Test] public void DoubleToByteClamp_PositiveInfinity_ReturnsMaxValue() => ConvertN.ToByte(double.PositiveInfinity, Conversion.Clamp).Should().Be(byte.MaxValue);
        [Test] public void DoubleToByteDefault_NaN_SameAsSystem() => AssertSame.Outcome(() => Convert.ToByte(double.NaN), () => ConvertN.ToByte(double.NaN, Conversion.Default));
        [Test] public void DoubleToByteDefault_NegativeInfinity_SameAsSystem() => AssertSame.Outcome(() => Convert.ToByte(double.NegativeInfinity), () => ConvertN.ToByte(double.NegativeInfinity, Conversion.Default));
        [Test] public void DoubleToByteDefault_PositiveInfinity_SameAsSystem() => AssertSame.Outcome(() => Convert.ToByte(double.PositiveInfinity), () => ConvertN.ToByte(double.PositiveInfinity, Conversion.Default));

        [Test] public void SingleToByteCast_NaN_SameAsSystem() => AssertSame.Outcome(() => unchecked((byte)float.NaN), () => ConvertN.ToByte(float.NaN, Conversion.Cast));
        [Test] public void SingleToByteCast_NegativeInfinity_SameAsSystem() => AssertSame.Outcome(() => unchecked((byte)float.NegativeInfinity), () => ConvertN.ToByte(float.NegativeInfinity, Conversion.Cast));
        [Test] public void SingleToByteCast_PositiveInfinity_SameAsSystem() => AssertSame.Outcome(() => unchecked((byte)float.PositiveInfinity), () => ConvertN.ToByte(float.PositiveInfinity, Conversion.Cast));
        [Test] public void SingleToByteCastClamp_NaN_ReturnsZero() => ConvertN.ToByte(float.NaN, Conversion.CastClamp).Should().Be((byte)0);
        [Test] public void SingleToByteCastClamp_NegativeInfinity_ReturnsMinValue() => ConvertN.ToByte(float.NegativeInfinity, Conversion.CastClamp).Should().Be(byte.MinValue);
        [Test] public void SingleToByteCastClamp_PositiveInfinity_ReturnsMaxValue() => ConvertN.ToByte(float.PositiveInfinity, Conversion.CastClamp).Should().Be(byte.MaxValue);
        [Test] public void SingleToByteClamp_NaN_ReturnsZero() => ConvertN.ToByte(float.NaN, Conversion.Clamp).Should().Be((byte)0);
        [Test] public void SingleToByteClamp_NegativeInfinity_ReturnsMinValue() => ConvertN.ToByte(float.NegativeInfinity, Conversion.Clamp).Should().Be(byte.MinValue);
        [Test] public void SingleToByteClamp_PositiveInfinity_ReturnsMaxValue() => ConvertN.ToByte(float.PositiveInfinity, Conversion.Clamp).Should().Be(byte.MaxValue);
        [Test] public void SingleToByteDefault_NaN_SameAsSystem() => AssertSame.Outcome(() => Convert.ToByte(float.NaN), () => ConvertN.ToByte(float.NaN, Conversion.Default));
        [Test] public void SingleToByteDefault_NegativeInfinity_SameAsSystem() => AssertSame.Outcome(() => Convert.ToByte(float.NegativeInfinity), () => ConvertN.ToByte(float.NegativeInfinity, Conversion.Default));
        [Test] public void SingleToByteDefault_PositiveInfinity_SameAsSystem() => AssertSame.Outcome(() => Convert.ToByte(float.PositiveInfinity), () => ConvertN.ToByte(float.PositiveInfinity, Conversion.Default));

        [Test] public void Int16ToUInt16Cast_MaxValue_SameAsSystem() => AssertSame.Outcome(() => unchecked((ushort)short.MaxValue), () => ConvertN.ToUInt16(short.MaxValue, Conversion.Cast));
        [Test] public void Int16ToUInt16Cast_MinValue_SameAsSystem() => AssertSame.Outcome(() => unchecked((ushort)short.MinValue), () => ConvertN.ToUInt16(short.MinValue, Conversion.Cast));
        [Test] public void Int16ToUInt16CastClamp_MinValue_ReturnsMinValue() => AssertSame.Outcome(() => ushort.MinValue, () => ConvertN.ToUInt16(short.MinValue, Conversion.CastClamp));
        [Test] public void Int16ToUInt16Default_MaxValue_SameAsSystem() => AssertSame.Outcome(() => Convert.ToUInt16(short.MaxValue), () => ConvertN.ToUInt16(short.MaxValue, Conversion.Default));
        [Test] public void Int16ToUInt16Default_MinValue_SameAsSystem() => AssertSame.Outcome(() => Convert.ToUInt16(short.MinValue), () => ConvertN.ToUInt16(short.MinValue, Conversion.Default));
        [Test] public void Int16ToUInt16DefaultClamp_MinValue_ReturnsMinValue() => AssertSame.Outcome(() => ushort.MinValue, () => ConvertN.ToUInt16(short.MinValue, Conversion.Clamp));

        [Test] public void DoubleToSingleClamp_MaxValue_ReturnsSingleMaxValue() => ConvertN.ToSingle(double.MaxValue, Conversion.Clamp).Should().Be(float.MaxValue);
        [Test] public void DoubleToSingleClamp_MinValue_ReturnsSingleMinValue() => ConvertN.ToSingle(double.MinValue, Conversion.Clamp).Should().Be(float.MinValue);
        [Test] public void DoubleToSingleCastClamp_MaxValue_ReturnsSingleMaxValue() => ConvertN.ToSingle(double.MaxValue, Conversion.CastClamp).Should().Be(float.MaxValue);
        [Test] public void DoubleToSingleCastClamp_MinValue_ReturnsSingleMinValue() => ConvertN.ToSingle(double.MinValue, Conversion.CastClamp).Should().Be(float.MinValue);

        [Test] public void DoubleToDecimalClamp_MaxValue_ReturnsSingleMaxValue() => ConvertN.ToDecimal(double.MaxValue, Conversion.Clamp).Should().Be(decimal.MaxValue);
        [Test] public void DoubleToDecimalClamp_MinValue_ReturnsSingleMinValue() => ConvertN.ToDecimal(double.MinValue, Conversion.Clamp).Should().Be(decimal.MinValue);
        [Test] public void DoubleToDecimalCastClamp_MaxValue_ReturnsSingleMaxValue() => ConvertN.ToDecimal(double.MaxValue, Conversion.CastClamp).Should().Be(decimal.MaxValue);
        [Test] public void DoubleToDecimalCastClamp_MinValue_ReturnsSingleMinValue() => ConvertN.ToDecimal(double.MinValue, Conversion.CastClamp).Should().Be(decimal.MinValue);

        [Test]
        public void AllMethods_UnrecognisedConversion_MayOnlyThrowArgumentOutOfRange()
        {
            //arrange
            foreach (MethodInfo method in GetMethodsWithConversionParameter())
            {
                object[] parameters = new Fixture().MockParameters(method);
                int index = Array.FindIndex(parameters, x => x is Conversion);
                while (Enum.IsDefined(typeof(Conversion), (Conversion)parameters[index]))
                {
                    parameters[index] = (Conversion)Random.Next();
                }

                try
                {
                    //act
                    method.Invoke(null, parameters);
                }
                catch (Exception exception)
                {
                    //assert
                    exception.InnerException.Should().BeOfType<ArgumentOutOfRangeException>();
                    exception.InnerException.Message.ToLowerInvariant().Should().Contain("mode");
                }
            }
        }
    }
}
