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
using Jodo.Benchmarking;
using Jodo.Numerics.Clamped;
using Jodo.Primitives;

namespace Jodo.Numerics.Benchmarks
{
    [ExcludeFromCodeCoverage]
    public static class NumericsBenchmarks
    {
        private static readonly Random Random = new Random();

        [Benchmark]
        public static Benchmark Int32NArithmetic_Versus_Int32Arithmetic()
        {
            return Benchmark
                .Using(LowMagnitudeWithInt32<Int32N>)
                .Measure(x => (((x.Numeric + x.Numeric) * x.Numeric) - x.Numeric) / x.Numeric)
                .Versus(x => (((x.Int32 + x.Int32) * x.Int32) - x.Int32) / x.Int32);
        }

        [Benchmark]
        public static Benchmark Int32MArithmetic_Versus_Int32Arithmetic()
        {
            return Benchmark
                .Using(LowMagnitudeWithInt32<Int32M>)
                .Measure(x => (((x.Numeric + x.Numeric) * x.Numeric) - x.Numeric) / x.Numeric)
                .Versus(x => (((x.Int32 + x.Int32) * x.Int32) - x.Int32) / x.Int32);
        }

        [Benchmark]
        public static Benchmark SingleNArithmetic_Versus_SingleArithmetic()
        {
            return Benchmark
                .Using(LowMagnitudeWithSingle<SingleN>)
                .Measure(x => (((x.Numeric + x.Numeric) * x.Numeric) - x.Numeric) / x.Numeric)
                .Versus(x => (((x.Single + x.Single) * x.Single) - x.Single) / x.Single);
        }

        [Benchmark]
        public static Benchmark SingleMArithmetic_Versus_SingleArithmetic()
        {
            return Benchmark
                .Using(LowMagnitudeWithSingle<SingleM>)
                .Measure(x => (((x.Numeric + x.Numeric) * x.Numeric) - x.Numeric) / x.Numeric)
                .Versus(x => (((x.Single + x.Single) * x.Single) - x.Single) / x.Single);
        }

        [Benchmark]
        public static Benchmark DoubleNArithmetic_Versus_DoubleArithmetic()
        {
            return Benchmark
                .Using(LowMagnitudeWithDouble<DoubleN>)
                .Measure(x => (((x.Numeric + x.Numeric) * x.Numeric) - x.Numeric) / x.Numeric)
                .Versus(x => (((x.Double + x.Double) * x.Double) - x.Double) / x.Double);
        }

        [Benchmark]
        public static Benchmark DoubleMArithmetic_Versus_DoubleArithmetic()
        {
            return Benchmark
                .Using(LowMagnitudeWithDouble<DoubleM>)
                .Measure(x => (((x.Numeric + x.Numeric) * x.Numeric) - x.Numeric) / x.Numeric)
                .Versus(x => (((x.Double + x.Double) * x.Double) - x.Double) / x.Double);
        }

        [Benchmark]
        public static Benchmark DoubleNLogarithm_Versus_DoubleLogarithm()
        {
            return Benchmark
                .Using(LowMagnitudeWithDouble<DoubleN>)
                .Measure(x => MathN.Log(x.Numeric, 1))
                .Versus(x => Math.Log(x.Double, 1));
        }

        [Benchmark]
        public static Benchmark DoubleNRounding_Versus_DoubleRounding()
        {
            return Benchmark
                .Using(LowMagnitudeWithDouble<DoubleN>)
                .Measure(x => MathN.Round(x.Numeric, 1))
                .Versus(x => Math.Round(x.Double, 1));
        }

        [Benchmark]
        public static Benchmark Fix64Logarithm_Versus_DoubleLogarithm()
        {
            return Benchmark
                .Using(LowMagnitudeWithDouble<Fix64>)
                .Measure(x => MathN.Log(x.Numeric, 1))
                .Versus(x => Math.Log(x.Double, 1));
        }

        [Benchmark]
        public static Benchmark Fix64Rounding_Versus_DoubleRounding()
        {
            return Benchmark
                .Using(LowMagnitudeWithDouble<Fix64>)
                .Measure(x => MathN.Round(x.Numeric, 1))
                .Versus(x => Math.Round(x.Double, 1));
        }

        [Benchmark]
        public static Benchmark Fix64StringParsing_Versus_DoubleStringParsing()
        {
            return Benchmark
                .Using(() => Random.NextVariant<SingleN>(Variants.LowMagnitude).ToString())
                .Measure(x => Fix64.Parse(x))
                .Versus(x => double.Parse(x));
        }

        [Benchmark]
        public static Benchmark Fix64Random_Versus_DoubleRandom()
        {
            return Benchmark
                .Using(() => new Random())
                .Measure(x => x.NextNumeric<Fix64>())
                .Versus(x => x.NextDouble());
        }

        [Benchmark]
        public static Benchmark Fix64ToByteArray_Versus_DoubleToByteArray()
        {
            return Benchmark
                .Using(LowMagnitudeWithDouble<Fix64>)
                .Measure(x => BitConverterN.GetBytes(x.Numeric))
                .Versus(x => BitConverter.GetBytes(x.Double));
        }

        [Benchmark]
        public static Benchmark Fix64FromByteArray_Versus_DoubleFromByteArray()
        {
            return Benchmark
                .Using(() =>
                    {
                        double value = Random.NextDouble(100, 1000);
                        byte[] doubleBytes = BitConverter.GetBytes(value);
                        byte[] numericBytes = BitConverterN.GetBytes((Fix64)value);
                        return (doubleBytes, numericBytes);
                    })
                .Measure(x => BitConverterN.ToNumeric<Fix64>(x.numericBytes, 0))
                .Versus(x => BitConverter.ToDouble(x.doubleBytes));
        }

        private static (int Int32, TNumeric Numeric) LowMagnitudeWithInt32<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
        {
            int value = 1 + Math.Abs(Random.NextVariant<Int32N>(Variants.LowMagnitude));
            return (value, ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast));
        }

        private static (float Single, TNumeric Numeric) LowMagnitudeWithSingle<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
        {
            float value = 1 + Math.Abs(Random.NextVariant<SingleN>(Variants.LowMagnitude));
            return (value, ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast));
        }

        private static (double Double, TNumeric Numeric) LowMagnitudeWithDouble<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
        {
            double value = 1 + Math.Abs(Random.NextVariant<DoubleN>(Variants.LowMagnitude));
            return (value, ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast));
        }
    }
}
