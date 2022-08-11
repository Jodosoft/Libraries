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

using System.Linq.Expressions;
using System.Reflection;

namespace Jodo.Primitives
{
    public static class DynamicInvoke
    {
        public static T AdditionOperator<T>(T left, T right)
            => Invoke<T>(Expression.Add(Expression.Constant(left), Expression.Constant(right)));

        public static T BitwiseComplementOperator<T>(T left)
            => Invoke<T>(Expression.Not(Expression.Constant(left)));

        public static T ConversionOperator<T>(object value)
            => Invoke<T>(Expression.Convert(Expression.Convert(Expression.Constant(value), value.GetType()), typeof(T)));

        public static T DecrementOperator<T>(T value)
            => Invoke<T>(Expression.Decrement(Expression.Constant(value)));

        public static T DivisionOperator<T>(T left, T right)
            => Invoke<T>(Expression.Divide(Expression.Constant(left), Expression.Constant(right)));

        public static bool EqualityOperator<T>(T left, T right)
            => Invoke<bool>(Expression.Equal(Expression.Constant(left), Expression.Constant(right)));

        public static bool GreaterThanOperator<T>(T left, T right)
            => Invoke<bool>(Expression.GreaterThan(Expression.Constant(left), Expression.Constant(right)));

        public static bool GreaterThanOrEqualOperator<T>(T left, T right)
            => Invoke<bool>(Expression.GreaterThanOrEqual(Expression.Constant(left), Expression.Constant(right)));

        public static T IncrementOperator<T>(T value)
            => Invoke<T>(Expression.Increment(Expression.Constant(value)));

        public static bool InequalityOperator<T>(T left, T right)
            => Invoke<bool>(Expression.NotEqual(Expression.Constant(left), Expression.Constant(right)));

        public static T LeftShiftOperator<T>(T left, int right)
            => Invoke<T>(Expression.LeftShift(Expression.Constant(left), Expression.Constant(right)));

        public static bool LessThanOperator<T>(T left, T right)
            => Invoke<bool>(Expression.LessThan(Expression.Constant(left), Expression.Constant(right)));

        public static bool LessThanOrEqualOperator<T>(T left, T right)
            => Invoke<bool>(Expression.LessThanOrEqual(Expression.Constant(left), Expression.Constant(right)));

        public static T LogicalAndOperator<T>(T left, T right)
            => Invoke<T>(Expression.And(Expression.Constant(left), Expression.Constant(right)));

        public static T LogicalExclusiveOrOperator<T>(T left, T right)
            => Invoke<T>(Expression.ExclusiveOr(Expression.Constant(left), Expression.Constant(right)));

        public static T LogicalOrOperator<T>(T left, T right)
            => Invoke<T>(Expression.Or(Expression.Constant(left), Expression.Constant(right)));

        public static T MultiplicationOperator<T>(T left, T right)
            => Invoke<T>(Expression.Multiply(Expression.Constant(left), Expression.Constant(right)));

        public static T RemainderOperator<T>(T left, T right)
            => Invoke<T>(Expression.Modulo(Expression.Constant(left), Expression.Constant(right)));

        public static T RightShiftOperator<T>(T left, int right)
            => Invoke<T>(Expression.RightShift(Expression.Constant(left), Expression.Constant(right)));

        public static T SubtractionOperator<T>(T left, T right)
            => Invoke<T>(Expression.Subtract(Expression.Constant(left), Expression.Constant(right)));

        public static T UnaryMinusOperator<T>(T left)
            => Invoke<T>(Expression.Negate(Expression.Constant(left)));

        public static T UnaryPlusOperator<T>(T left)
            => Invoke<T>(Expression.UnaryPlus(Expression.Constant(left)));

        private static T Invoke<T>(Expression expression)
        {
            try
            {
                return (T)Expression.Lambda(expression).Compile().DynamicInvoke();
            }
            catch (TargetInvocationException exception)
            {

                throw exception.InnerException;
            }
        }
    }
}
