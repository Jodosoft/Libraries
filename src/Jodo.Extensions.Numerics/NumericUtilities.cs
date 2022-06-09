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

namespace Jodo.Extensions.Numerics
{
    public static class NumericUtilities
    {
        public const float DegreesPerRadianF = 180f / MathF.PI;
        public const float RadiansPerDegreeF = MathF.PI / 180;

        public const double DegreesPerRadian = 180d / Math.PI;
        public const double RadiansPerDegree = Math.PI / 180d;

        public const decimal DegreesPerRadianM = 180m / (decimal)Math.PI;
        public const decimal RadiansPerDegreeM = (decimal)Math.PI / 180m;

        public static float BitwiseComplement(float left)
        {
            var leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left));
            return BitConverter.ToSingle(BitConverter.GetBytes(~leftBits));
        }

        public static double BitwiseComplement(double left)
        {
            var leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left));
            return BitConverter.ToDouble(BitConverter.GetBytes(~leftBits));
        }

        public static decimal BitwiseComplement(decimal left)
        {
            var bits = decimal.GetBits(left);
            bits[0] = ~bits[0];
            bits[1] = ~bits[1];
            bits[2] = ~bits[2];
            return new decimal(bits);
        }

        public static float LeftShift(float left, int right)
        {
            var leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left));
            return BitConverter.ToSingle(BitConverter.GetBytes(leftBits << right));
        }

        public static double LeftShift(double left, int right)
        {
            var leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left));
            return BitConverter.ToDouble(BitConverter.GetBytes(leftBits << right));
        }

        public static decimal LeftShift(decimal left, int right)
        {
            var leftBits = decimal.GetBits(left);
            leftBits[0] = leftBits[0] << right;
            leftBits[1] = leftBits[1] << right;
            leftBits[2] = leftBits[2] << right;
            return new decimal(leftBits);
        }

        public static float LogicalAnd(float left, float right)
        {
            var leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left));
            var rightBits = BitConverter.ToInt32(BitConverter.GetBytes(right));
            return BitConverter.ToSingle(BitConverter.GetBytes(leftBits & rightBits));
        }

        public static double LogicalAnd(double left, double right)
        {
            var leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left));
            var rightBits = BitConverter.ToInt64(BitConverter.GetBytes(right));
            return BitConverter.ToDouble(BitConverter.GetBytes(leftBits & rightBits));
        }

        public static decimal LogicalAnd(decimal left, decimal right)
        {
            var leftBits = decimal.GetBits(left);
            var rightBits = decimal.GetBits(right);
            leftBits[0] = leftBits[0] & rightBits[0];
            leftBits[1] = leftBits[1] & rightBits[1];
            leftBits[2] = leftBits[2] & rightBits[2];
            return new decimal(leftBits);
        }

        public static float LogicalExclusiveOr(float left, float right)
        {
            var leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left));
            var rightBits = BitConverter.ToInt32(BitConverter.GetBytes(right));
            return BitConverter.ToSingle(BitConverter.GetBytes(leftBits ^ rightBits));
        }

        public static double LogicalExclusiveOr(double left, double right)
        {
            var leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left));
            var rightBits = BitConverter.ToInt64(BitConverter.GetBytes(right));
            return BitConverter.ToDouble(BitConverter.GetBytes(leftBits ^ rightBits));
        }

        public static decimal LogicalExclusiveOr(decimal left, decimal right)
        {
            var leftBits = decimal.GetBits(left);
            var rightBits = decimal.GetBits(right);
            leftBits[0] = leftBits[0] ^ rightBits[0];
            leftBits[1] = leftBits[1] ^ rightBits[1];
            leftBits[2] = leftBits[2] ^ rightBits[2];
            return new decimal(leftBits);
        }

        public static float LogicalOr(float left, float right)
        {
            var leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left));
            var rightBits = BitConverter.ToInt32(BitConverter.GetBytes(right));
            return BitConverter.ToSingle(BitConverter.GetBytes(leftBits | rightBits));
        }

        public static double LogicalOr(double left, double right)
        {
            var leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left));
            var rightBits = BitConverter.ToInt64(BitConverter.GetBytes(right));
            return BitConverter.ToDouble(BitConverter.GetBytes(leftBits | rightBits));
        }

        public static decimal LogicalOr(decimal left, decimal right)
        {
            var leftBits = decimal.GetBits(left);
            var rightBits = decimal.GetBits(right);
            leftBits[0] = leftBits[0] | rightBits[0];
            leftBits[1] = leftBits[1] | rightBits[1];
            leftBits[2] = leftBits[2] | rightBits[2];
            return new decimal(leftBits);
        }

        public static float RightShift(float left, int right)
        {
            var leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left));
            return BitConverter.ToSingle(BitConverter.GetBytes(leftBits >> right));
        }

        public static double RightShift(double left, int right)
        {
            var leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left));
            return BitConverter.ToDouble(BitConverter.GetBytes(leftBits >> right));
        }

        public static decimal RightShift(decimal left, int right)
        {
            var leftBits = decimal.GetBits(left);
            leftBits[0] = leftBits[0] >> right;
            leftBits[1] = leftBits[1] >> right;
            leftBits[2] = leftBits[2] >> right;
            return new decimal(leftBits);
        }
    }
}
