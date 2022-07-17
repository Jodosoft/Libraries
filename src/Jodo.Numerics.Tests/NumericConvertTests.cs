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
using System.Reflection;
using FluentAssertions;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    [SuppressMessage("Style", "IDE0004:Cast is redundant")]
    public class NumericConvertTests : GlobalFixtureBase
    {
        [Test] public void DoubleToByteCast_NaN_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(double.NaN, Conversion.Cast), unchecked((byte)double.NaN));
        [Test] public void DoubleToByteCast_NegativeInfinity_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(double.NegativeInfinity, Conversion.Cast), unchecked((byte)double.NegativeInfinity));
        [Test] public void DoubleToByteCast_PositiveInfinity_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(double.PositiveInfinity, Conversion.Cast), unchecked((byte)double.PositiveInfinity));
        [Test] public void DoubleToByteCastClamp_NaN_ReturnsZero() => NumericConvert.ToByte(double.NaN, Conversion.CastClamp).Should().Be((byte)0);
        [Test] public void DoubleToByteCastClamp_NegativeInfinity_ReturnsMinValue() => NumericConvert.ToByte(double.NegativeInfinity, Conversion.CastClamp).Should().Be(byte.MinValue);
        [Test] public void DoubleToByteCastClamp_PositiveInfinity_ReturnsMaxValue() => NumericConvert.ToByte(double.PositiveInfinity, Conversion.CastClamp).Should().Be(byte.MaxValue);
        [Test] public void DoubleToByteClamp_NaN_ReturnsZero() => NumericConvert.ToByte(double.NaN, Conversion.Clamp).Should().Be((byte)0);
        [Test] public void DoubleToByteClamp_NegativeInfinity_ReturnsMinValue() => NumericConvert.ToByte(double.NegativeInfinity, Conversion.Clamp).Should().Be(byte.MinValue);
        [Test] public void DoubleToByteClamp_PositiveInfinity_ReturnsMaxValue() => NumericConvert.ToByte(double.PositiveInfinity, Conversion.Clamp).Should().Be(byte.MaxValue);
        [Test] public void DoubleToByteDefault_NaN_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(double.NaN, Conversion.Default), () => Convert.ToByte(double.NaN));
        [Test] public void DoubleToByteDefault_NegativeInfinity_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(double.NegativeInfinity, Conversion.Default), () => Convert.ToByte(double.NegativeInfinity));
        [Test] public void DoubleToByteDefault_PositiveInfinity_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(double.PositiveInfinity, Conversion.Default), () => Convert.ToByte(double.PositiveInfinity));

        [Test] public void SingleToByteCast_NaN_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(float.NaN, Conversion.Cast), unchecked((byte)float.NaN));
        [Test] public void SingleToByteCast_NegativeInfinity_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(float.NegativeInfinity, Conversion.Cast), unchecked((byte)float.NegativeInfinity));
        [Test] public void SingleToByteCast_PositiveInfinity_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(float.PositiveInfinity, Conversion.Cast), unchecked((byte)float.PositiveInfinity));
        [Test] public void SingleToByteCastClamp_NaN_ReturnsZero() => NumericConvert.ToByte(float.NaN, Conversion.CastClamp).Should().Be((byte)0);
        [Test] public void SingleToByteCastClamp_NegativeInfinity_ReturnsMinValue() => NumericConvert.ToByte(float.NegativeInfinity, Conversion.CastClamp).Should().Be(byte.MinValue);
        [Test] public void SingleToByteCastClamp_PositiveInfinity_ReturnsMaxValue() => NumericConvert.ToByte(float.PositiveInfinity, Conversion.CastClamp).Should().Be(byte.MaxValue);
        [Test] public void SingleToByteClamp_NaN_ReturnsZero() => NumericConvert.ToByte(float.NaN, Conversion.Clamp).Should().Be((byte)0);
        [Test] public void SingleToByteClamp_NegativeInfinity_ReturnsMinValue() => NumericConvert.ToByte(float.NegativeInfinity, Conversion.Clamp).Should().Be(byte.MinValue);
        [Test] public void SingleToByteClamp_PositiveInfinity_ReturnsMaxValue() => NumericConvert.ToByte(float.PositiveInfinity, Conversion.Clamp).Should().Be(byte.MaxValue);
        [Test] public void SingleToByteDefault_NaN_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(float.NaN, Conversion.Default), () => Convert.ToByte(float.NaN));
        [Test] public void SingleToByteDefault_NegativeInfinity_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(float.NegativeInfinity, Conversion.Default), () => Convert.ToByte(float.NegativeInfinity));
        [Test] public void SingleToByteDefault_PositiveInfinity_SameAsSystem() => Same.Outcome(() => NumericConvert.ToByte(float.PositiveInfinity, Conversion.Default), () => Convert.ToByte(float.PositiveInfinity));

        [Test] public void Int16ToUInt16Cast_MaxValue_SameAsSystem() => Same.Outcome(() => NumericConvert.ToUInt16(short.MaxValue, Conversion.Cast), () => unchecked((ushort)short.MaxValue));
        [Test] public void Int16ToUInt16Cast_MinValue_SameAsSystem() => Same.Outcome(() => NumericConvert.ToUInt16(short.MinValue, Conversion.Cast), () => unchecked((ushort)short.MinValue));
        [Test] public void Int16ToUInt16CastClamp_MinValue_ReturnsMinValue() => Same.Outcome(() => NumericConvert.ToUInt16(short.MinValue, Conversion.CastClamp), ushort.MinValue);
        [Test] public void Int16ToUInt16Default_MaxValue_SameAsSystem() => Same.Outcome(() => NumericConvert.ToUInt16(short.MaxValue, Conversion.Default), () => Convert.ToUInt16(short.MaxValue));
        [Test] public void Int16ToUInt16Default_MinValue_SameAsSystem() => Same.Outcome(() => NumericConvert.ToUInt16(short.MinValue, Conversion.Default), () => Convert.ToUInt16(short.MinValue));
        [Test] public void Int16ToUInt16DefaultClamp_MinValue_ReturnsMinValue() => Same.Outcome(() => NumericConvert.ToUInt16(short.MinValue, Conversion.Clamp), ushort.MinValue);

        [Test]
        public void AllMethods_UnrecognisedConversion_MayOnlyThrowArgumentOutOfRange()
        {
            foreach (MethodInfo method in typeof(NumericConvert).GetMethods(
                BindingFlags.Static & BindingFlags.Public & BindingFlags.DeclaredOnly))
            {
                //arrange
                object[] parameters = Fixture.MockParameters(method);
                int index = Array.FindIndex(parameters, x => x is Conversion);
                if (index < 0) throw new InvalidOperationException();
                while (Enum.IsDefined(typeof(Conversion), (Conversion)parameters[index]))
                {
                    parameters[index] = (Conversion)Random.Next();
                }

                //act
                try
                {
                    method.Invoke(null, parameters);
                }
                catch (Exception exception)
                {
                    exception.InnerException.Should().BeOfType<ArgumentOutOfRangeException>();
                    exception.InnerException.Message.ToLowerInvariant().Should().Contain("mode");
                }
            }
        }
    }
}
