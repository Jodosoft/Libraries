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
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<byte>(value),
                () => ConvertN.ToByte(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToByteConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => ((IConvertible)value).ToByte(null),
                () => ConvertN.ToByte(value),
                () => ConvertN.ToByte(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromByteCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            byte value = Random.NextByteExtreme();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromByteConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            byte value = Random.NextByteExtreme();

            //act
            //assert
            Same.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToSByteCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<sbyte>(value),
                () => ConvertN.ToSByte(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToSByteConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => ((IConvertible)value).ToSByte(null),
                () => ConvertN.ToSByte(value),
                () => ConvertN.ToSByte(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromSByteCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            sbyte value = Random.NextSByteExtreme();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromSByteConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            sbyte value = Random.NextSByteExtreme();

            //act
            //assert
            Same.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt16CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<short>(value),
                () => ConvertN.ToInt16(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt16ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => ((IConvertible)value).ToInt16(null),
                () => ConvertN.ToInt16(value),
                () => ConvertN.ToInt16(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt16CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            short value = Random.NextInt16Extreme();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt16ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            short value = Random.NextInt16Extreme();

            //act
            //assert
            Same.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt16CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<ushort>(value),
                () => ConvertN.ToUInt16(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt16ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => ((IConvertible)value).ToUInt16(null),
                () => ConvertN.ToUInt16(value),
                () => ConvertN.ToUInt16(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt16CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            ushort value = Random.NextUInt16Extreme();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt16ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            ushort value = Random.NextUInt16Extreme();

            //act
            //assert
            Same.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt32CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<int>(value),
                () => ConvertN.ToInt32(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt32ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => ((IConvertible)value).ToInt32(null),
                () => ConvertN.ToInt32(value),
                () => ConvertN.ToInt32(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt32CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            int value = Random.NextInt32Extreme();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt32ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            int value = Random.NextInt32Extreme();

            //act
            //assert
            Same.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt32CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<uint>(value),
                () => ConvertN.ToUInt32(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt32ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => ((IConvertible)value).ToUInt32(null),
                () => ConvertN.ToUInt32(value),
                () => ConvertN.ToUInt32(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt32CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            uint value = Random.NextUInt32Extreme();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt32ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            uint value = Random.NextUInt32Extreme();

            //act
            //assert
            Same.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt64CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<long>(value),
                () => ConvertN.ToInt64(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt64ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => ((IConvertible)value).ToInt64(null),
                () => ConvertN.ToInt64(value),
                () => ConvertN.ToInt64(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt64CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            long value = Random.NextInt64Extreme();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromInt64ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            long value = Random.NextInt64Extreme();

            //act
            //assert
            Same.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt64CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<ulong>(value),
                () => ConvertN.ToUInt64(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt64ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => ((IConvertible)value).ToUInt64(null),
                () => ConvertN.ToUInt64(value),
                () => ConvertN.ToUInt64(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt64CastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            ulong value = Random.NextUInt64Extreme();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromUInt64ConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            ulong value = Random.NextUInt64Extreme();

            //act
            //assert
            Same.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToSingleCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<float>(value),
                () => ConvertN.ToSingle(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToSingleConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => ((IConvertible)value).ToSingle(null),
                () => ConvertN.ToSingle(value),
                () => ConvertN.ToSingle(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromSingleCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            float value = Random.NextSingleExtreme();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromSingleConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            float value = Random.NextSingleExtreme();

            //act
            //assert
            Same.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToDoubleCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<double>(value),
                () => ConvertN.ToDouble(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToDoubleConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => ((IConvertible)value).ToDouble(null),
                () => ConvertN.ToDouble(value),
                () => ConvertN.ToDouble(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromDoubleCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            double value = Random.NextDoubleExtreme();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromDoubleConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            double value = Random.NextDoubleExtreme();

            //act
            //assert
            Same.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToDecimalCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<decimal>(value),
                () => ConvertN.ToDecimal(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void ToDecimalConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            TNumeric value = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Result(
                () => ((IConvertible)value).ToDecimal(null),
                () => ConvertN.ToDecimal(value),
                () => ConvertN.ToDecimal(value, Conversion.Clamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromDecimalCastMethods_RandomValues_ConsistentResults()
        {
            //arrange
            decimal value = Random.NextDecimalExtreme();

            //act
            //assert
            Same.Result(
                () => DynamicInvoke.ConversionOperator<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.CastClamp));
        }

        [Test, Repeat(RandomVariations)]
        public void FromDecimalConvertMethods_RandomValues_ConsistentResults()
        {
            //arrange
            decimal value = Random.NextDecimalExtreme();

            //act
            //assert
            Same.Result(
                () => ConvertN.ToNumeric<TNumeric>(value),
                () => ConvertN.ToNumeric<TNumeric>(value, Conversion.Clamp));
        }
    }
}
