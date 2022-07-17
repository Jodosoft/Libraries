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
using System.IO;
using System.Text;
using FluentAssertions;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    [NonParallelizable]
    public sealed class Showcase : GlobalFixtureBase
    {
        public StringBuilder ConsoleOuput;

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
            Int32N w = -100 + MathN.Max<Int32N>(1234, 4321);
            Vector2<Int32N> v = new Vector2<Int32N>(w, w >> 0b11);

            Fix64 f = 2 * MathN.PI<Fix64>();
            byte[] b = BitConverter<Fix64>.GetBytes(f);

            Console.WriteLine(w); // output: 4221
            Console.WriteLine($"{v:X}"); // output: <107D, 20F>

            Console.WriteLine(f); // output: 6.283184
            Console.WriteLine(b.ToString()); // output: System.Byte[]

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("4221", "<107D, 20F>", "6.283184", "System.Byte[]");
        }

        [Test]
        public void FixedPointArithmetic_LargeValues_NoLossOfPrecision()
        {
            float floatingPoint = 1000000 + MathF.PI;
            Fix64 fixedPoint = 1000000 + MathN.PI<Fix64>();

            Console.WriteLine(floatingPoint); // output: 1000003.1
            Console.WriteLine(fixedPoint); // output: 1000003.141592

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("1000003.1", "1000003.141592");
        }

        [Test]
        public void StringFormatting()
        {
            Int32N var1 = (Int32N)1024;
            Fix64 var2 = (Fix64)99.54322f;

            Console.WriteLine($"{var1:N}"); // output: 1,024.00
            Console.WriteLine($"{var1:X}"); // output: 400
            Console.WriteLine($"{var2:E}"); // output: 9.954322E+001
            Console.WriteLine($"{var2:000.000}"); // output: 099.543

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("1,024.00", "400", "9.954322E+001", "099.543");
        }

        [Test]
        public void RandomValueGeneration()
        {
            DoubleN var1 = Random.NextNumeric<DoubleN>();
            DoubleN var2 = Random.NextNumeric<DoubleN>(100, 120);

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
        public void FixedPointArithmetic()
        {
            Fix64 third = 1 / 3f;
            Fix64 pi = MathN.PI<Fix64>();
            Fix64 tooSmall = (Fix64)0.0000001;

            Console.WriteLine(third); // output: 0.333333
            Console.WriteLine(pi); // output: 3.141592
            Console.WriteLine(tooSmall); // output: 0

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("0.333333", "3.141592", "0");
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
        public void BitConverterN()
        {
            byte[] res1 = BitConverter.GetBytes((ulong)1234567890);
            byte[] res2 = BitConverter<UFix64>.GetBytes((UFix64)256.512);

            Console.WriteLine(BitConverter.ToString(res1)); // output: D2-02-96-49-00-00-00-00
            Console.WriteLine(BitConverter.ToString(res2)); // output: 00-10-4A-0F-00-00-00-00

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("D2-02-96-49-00-00-00-00", "00-10-4A-0F-00-00-00-00");
        }
    }
}
#endif
