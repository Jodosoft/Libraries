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

#if NET5_0_OR_GREATER

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using FluentAssertions;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

using MyNumberType = Jodo.Numerics.DoubleN;

namespace Jodo.Numerics.Tests
{
    [NonParallelizable]
    [SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "For demonstration.")]
    public sealed class Showcase : GlobalFixtureBase
    {
        public StringBuilder ConsoleOuput { get; set; }

        [SetUp]
        public void SetUp()
        {
            ConsoleOuput = new StringBuilder();
            Console.SetOut(new StringWriter(ConsoleOuput));
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }

        [Test]
        public void NumericsSummary()
        {
            var value1 = MathN.Log10(99999 * (Fix64)3.444);
            var value2 = (Int32N)107 << 4;
            var value3 = BitConverterN.GetBytes(value1);
            var value4 = new Vector2N<Fix64>(101, -202);

            Console.WriteLine(value1); // output: 5.537058
            Console.WriteLine(value2.ToString("X")); // output: 6B0
            Console.WriteLine(value3); // output: System.Byte[]
            Console.WriteLine(value4); // output: <101, -202>

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("5.537058", "6B0", "System.Byte[]", "<101, -202>");
        }

        [Test]
        public void FixedPointArithmetic_ConstantPrecision_LowerMaximumMagnitude()
        {
            Fix64 fixedPoint = (Fix64)8000000000000 + MathN.PI<Fix64>();
            double floatingPoint = 8000000000000 + Math.PI;

            Console.WriteLine(fixedPoint); // output: 8000000000003.141592
            Console.WriteLine(floatingPoint); // output: 8000000000003.142

            Console.WriteLine(Fix64.MaxValue); // output: 9223372036854.775807
            Console.WriteLine(double.MaxValue); // output: 1.7976931348623157E+308

            Console.WriteLine();

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("8000000000003.141592", "8000000000003.142", "9223372036854.775807", "1.7976931348623157E+308");
        }

        [Test]
        public void StringFormatting()
        {
            Int32N var1 = 1023;
            Fix64 var2 = (Fix64)99.54322f;

            Console.WriteLine($"{var1:N2}"); // output: 1,023.00
            Console.WriteLine($"{var1:X}"); // output: 3FF
            Console.WriteLine($"{var2:E}"); // output: 9.954322E+001
            Console.WriteLine($"{var2:000.000}"); // output: 099.543

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("1,023.00", "3FF", "9.954322E+001", "099.543");
        }

        [Test]
        public void RandomValueGeneration()
        {
            DecimalN var1 = Random.NextNumeric<DecimalN>(Generation.Extended);
            DecimalN var2 = Random.NextNumeric<DecimalN>(100, 120, Generation.Extended);

            Console.WriteLine(var1); // output: -7.405808417991177E+115 (example)
            Console.WriteLine(var2); // output: 102.85086051826445 (example)

            ConsoleOuput.ToString().Should().Contain("1");
        }

        [Test]
        public void CastConvertAndClamp()
        {
            ByteN castResult = ConvertN.ToNumeric<ByteN>(1023, Conversion.Cast);
            ByteN convertResult = ConvertN.ToNumeric<ByteN>(199.956M, Conversion.Default);
            ByteN clampResult = ConvertN.ToNumeric<ByteN>(-100, Conversion.Clamp);

            Console.WriteLine(castResult); // output: 255
            Console.WriteLine(convertResult); // output: 200
            Console.WriteLine(clampResult); // output: 0

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("255", "200", "0");
        }

        [Test]
        public void FixedPointNumbers_Example()
        {
            Fix64 x = 100;
            Fix64 y = 2 * MathN.Cos(x);
            Fix64 z = Fix64.Parse("1000000.123456");
            Fix64 r = new Random(1).NextNumeric<Fix64>(100, 200);
            float f = ConvertN.ToSingle(z);
            byte[] bytes = BitConverterN.GetBytes(y);

            Console.WriteLine(x); // output: 100
            Console.WriteLine(y); // output: 1.724636
            Console.WriteLine(z); // output: 1000000.123456
            Console.WriteLine(r); // output: 124.866858
            Console.WriteLine(f); // output: 1000000.1
            Console.WriteLine(bytes.Length); // output: 8

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("100", "1.724636", "1000000.123456", "124.866858", "1000000.1", "8");
        }

        [Test]
        public void MathN_Examples()
        {
            float res1 = MathF.Log10(1000 * MathF.PI);
            Fix64 res2 = MathN.Log10(1000 * MathN.PI<Fix64>());

            Console.WriteLine(res1); // output: 3.49715
            Console.WriteLine(res2); // output: 3.497149

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("3.49715", "3.497149");
        }

        [Test]
        public void BitConverterN_Examples()
        {
            byte[] res1 = BitConverter.GetBytes((ulong)1234567890);
            byte[] res2 = BitConverterN.GetBytes((UFix64)256.512);

            Console.WriteLine(BitConverter.ToString(res1)); // output: D2-02-96-49-00-00-00-00
            Console.WriteLine(BitConverter.ToString(res2)); // output: 00-10-4A-0F-00-00-00-00

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("D2-02-96-49-00-00-00-00", "00-10-4A-0F-00-00-00-00");
        }

        [Test]
        public void RandomVariants_Examples()
        {
            var random = new Random(93);
            var num1 = random.NextVariant<Int16N>(Variants.LowMagnitude);
            var num2 = random.NextVariant<Int16N>(Variants.Defaults | Variants.Boundaries);

            Console.WriteLine(num1); // output: -26
            Console.WriteLine(num2); // output: 32767

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("-26", "32767");
        }

        [Test]
        public void FixedPoints_Examples()
        {
            var random = new Random(93);
            var num1 = random.NextVariant<Int16N>(Variants.LowMagnitude);
            var num2 = random.NextVariant<Int16N>(Variants.Defaults | Variants.Boundaries);

            Console.WriteLine(num1); // output: -26
            Console.WriteLine(num2); // output: 32767

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("-26", "32767");
        }

        [Test]
        public void MyNumberType_Examples()
        {
            MyNumberType fromLiteral = 3.123;
            MyNumberType usingOperators = (fromLiteral + 1) % 2;
            MyNumberType usingMath = MathN.Pow(fromLiteral, 2);
            MyNumberType fromRandom = new Random(1).NextNumeric<MyNumberType>(10, 20);
            MyNumberType fromString = MyNumberType.Parse("-7.4E+5");
            short conversion = ConvertN.ToInt16(usingMath);
            string stringFormat = $"{fromLiteral:N3}";
            byte[] asBytes = BitConverterN.GetBytes(usingMath);

            Console.WriteLine(fromLiteral); // output: 3.123
            Console.WriteLine(usingOperators); // output: 0.12300000000000022
            Console.WriteLine(usingMath); // output: 9.753129000000001
            Console.WriteLine(fromRandom); // output: 12.486685841570928
            Console.WriteLine(fromString); // output: -740000
            Console.WriteLine(conversion); // output: 10
            Console.WriteLine(stringFormat); // output: 3.123
            Console.WriteLine(asBytes); // output: System.Byte[]

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder(
                    "3.123", "0.12300000000000022", "9.753129000000001", "12.486685841570928",
                    "-740000", "10", "3.123", "System.Byte[]");
        }
    }
}
#endif
