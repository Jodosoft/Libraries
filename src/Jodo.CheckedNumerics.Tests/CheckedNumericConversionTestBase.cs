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
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.CheckedNumerics.Tests
{
    public abstract class CheckedNumericConversionTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumericExtended<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void ToByteCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<byte>(value),
                () => ConvertN.ToByte(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToByteConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => ((IConvertible)value).ToByte(null),
                () => (byte)((IConvertible)value).ToType(typeof(byte), null),
                () => ConvertN.ToByte(value),
                () => ConvertN.ToByte(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromByteCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            byte value = Random.NextVariant<ByteN>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromByteConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            byte value = Random.NextVariant<ByteN>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToSByteCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<sbyte>(value),
                () => ConvertN.ToSByte(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToSByteConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => ((IConvertible)value).ToSByte(null),
                () => (sbyte)((IConvertible)value).ToType(typeof(sbyte), null),
                () => ConvertN.ToSByte(value),
                () => ConvertN.ToSByte(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromSByteCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            sbyte value = Random.NextVariant<SByteN>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromSByteConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            sbyte value = Random.NextVariant<SByteN>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt16CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<short>(value),
                () => ConvertN.ToInt16(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt16ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => ((IConvertible)value).ToInt16(null),
                () => (short)((IConvertible)value).ToType(typeof(short), null),
                () => ConvertN.ToInt16(value),
                () => ConvertN.ToInt16(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt16CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            short value = Random.NextVariant<Int16N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt16ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            short value = Random.NextVariant<Int16N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt16CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<ushort>(value),
                () => ConvertN.ToUInt16(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt16ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => ((IConvertible)value).ToUInt16(null),
                () => (ushort)((IConvertible)value).ToType(typeof(ushort), null),
                () => ConvertN.ToUInt16(value),
                () => ConvertN.ToUInt16(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt16CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            ushort value = Random.NextVariant<UInt16N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt16ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            ushort value = Random.NextVariant<UInt16N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt32CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<int>(value),
                () => ConvertN.ToInt32(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt32ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => ((IConvertible)value).ToInt32(null),
                () => (int)((IConvertible)value).ToType(typeof(int), null),
                () => ConvertN.ToInt32(value),
                () => ConvertN.ToInt32(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt32CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            int value = Random.NextVariant<Int32N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt32ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            int value = Random.NextVariant<Int32N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt32CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<uint>(value),
                () => ConvertN.ToUInt32(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt32ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => ((IConvertible)value).ToUInt32(null),
                () => (uint)((IConvertible)value).ToType(typeof(uint), null),
                () => ConvertN.ToUInt32(value),
                () => ConvertN.ToUInt32(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt32CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            uint value = Random.NextVariant<UInt32N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt32ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            uint value = Random.NextVariant<UInt32N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt64CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<long>(value),
                () => ConvertN.ToInt64(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt64ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => ((IConvertible)value).ToInt64(null),
                () => (long)((IConvertible)value).ToType(typeof(long), null),
                () => ConvertN.ToInt64(value),
                () => ConvertN.ToInt64(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt64CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            long value = Random.NextVariant<Int64N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt64ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            long value = Random.NextVariant<Int64N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt64CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<ulong>(value),
                () => ConvertN.ToUInt64(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt64ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => ((IConvertible)value).ToUInt64(null),
                () => (ulong)((IConvertible)value).ToType(typeof(ulong), null),
                () => ConvertN.ToUInt64(value),
                () => ConvertN.ToUInt64(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt64CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            ulong value = Random.NextVariant<UInt64N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt64ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            ulong value = Random.NextVariant<UInt64N>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToSingleCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<float>(value),
                () => ConvertN.ToSingle(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToSingleConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => ((IConvertible)value).ToSingle(null),
                () => (float)((IConvertible)value).ToType(typeof(float), null),
                () => ConvertN.ToSingle(value),
                () => ConvertN.ToSingle(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromSingleCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            float value = Random.NextVariant<SingleN>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromSingleConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            float value = Random.NextVariant<SingleN>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToDoubleCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<double>(value),
                () => ConvertN.ToDouble(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToDoubleConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => ((IConvertible)value).ToDouble(null),
                () => (double)((IConvertible)value).ToType(typeof(double), null),
                () => ConvertN.ToDouble(value),
                () => ConvertN.ToDouble(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromDoubleCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            double value = Random.NextVariant<DoubleN>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromDoubleConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            double value = Random.NextVariant<DoubleN>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToDecimalCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<decimal>(value),
                () => ConvertN.ToDecimal(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToDecimalConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Result(
                () => ((IConvertible)value).ToDecimal(null),
                () => (decimal)((IConvertible)value).ToType(typeof(decimal), null),
                () => ConvertN.ToDecimal(value),
                () => ConvertN.ToDecimal(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromDecimalCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            decimal value = Random.NextVariant<DecimalN>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromDecimalConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            decimal value = Random.NextVariant<DecimalN>(Scenarios.All);

            //act
            //assert
            AssertSame.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }
    }
}
