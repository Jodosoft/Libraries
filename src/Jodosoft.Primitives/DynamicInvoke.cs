// Copyright (c) 2023 Joe Lawry-Short
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

namespace Jodosoft.Primitives
{
    /// <summary>
    ///     Provides static methods for invoking operators using reflection.
    /// </summary>
    public static class DynamicInvoke
    {
        /// <summary>
        ///     Uses reflection to invoke the addition operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T AdditionOperator<T>(T left, T right)
            => Invoke<T>(Expression.Add(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the bitwise complement operator for <typeparamref name="T"/> using
        ///     <paramref name="value"/> as the parameter. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="value">The value to pass to operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T BitwiseComplementOperator<T>(T value)
            => Invoke<T>(Expression.Not(Expression.Constant(value)));

        public static T ConversionOperator<T>(object value)
            => Invoke<T>(Expression.Convert(Expression.Convert(Expression.Constant(value), value.GetType()), typeof(T)));

        /// <summary>
        ///     Uses reflection to invoke the decrement operator for <typeparamref name="T"/> using
        ///     <paramref name="value"/> as the parameter. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="value">The value to pass to operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T DecrementOperator<T>(T value)
            => Invoke<T>(Expression.Decrement(Expression.Constant(value)));

        /// <summary>
        ///     Uses reflection to invoke the division operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T DivisionOperator<T>(T left, T right)
            => Invoke<T>(Expression.Divide(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the equality for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters, returning the result of the operation.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static bool EqualityOperator<T>(T left, T right)
            => Invoke<bool>(Expression.Equal(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the greater than operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static bool GreaterThanOperator<T>(T left, T right)
            => Invoke<bool>(Expression.GreaterThan(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the greater than or equal operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static bool GreaterThanOrEqualOperator<T>(T left, T right)
            => Invoke<bool>(Expression.GreaterThanOrEqual(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the increment operator for <typeparamref name="T"/> using
        ///     <paramref name="value"/> as the parameter. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="value">The value to pass to operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T IncrementOperator<T>(T value)
            => Invoke<T>(Expression.Increment(Expression.Constant(value)));

        /// <summary>
        ///     Uses reflection to invoke the inequality for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters, returning the result of the operation.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static bool InequalityOperator<T>(T left, T right)
            => Invoke<bool>(Expression.NotEqual(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the left-shift operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T LeftShiftOperator<T>(T left, int right)
            => Invoke<T>(Expression.LeftShift(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the less than operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static bool LessThanOperator<T>(T left, T right)
            => Invoke<bool>(Expression.LessThan(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the less than or equal operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static bool LessThanOrEqualOperator<T>(T left, T right)
            => Invoke<bool>(Expression.LessThanOrEqual(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the logical AND operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T LogicalAndOperator<T>(T left, T right)
            => Invoke<T>(Expression.And(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the logical exclusive OR operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T LogicalExclusiveOrOperator<T>(T left, T right)
            => Invoke<T>(Expression.ExclusiveOr(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the logical OR operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T LogicalOrOperator<T>(T left, T right)
            => Invoke<T>(Expression.Or(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the multiplication operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T MultiplicationOperator<T>(T left, T right)
            => Invoke<T>(Expression.Multiply(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the remainder operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T RemainderOperator<T>(T left, T right)
            => Invoke<T>(Expression.Modulo(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the right-shift operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T RightShiftOperator<T>(T left, int right)
            => Invoke<T>(Expression.RightShift(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the subtraction operator for <typeparamref name="T"/> using
        ///     <paramref name="left"/> and <paramref name="right"/> as the parameters. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="left">The left value to pass to operator.</param>
        /// <param name="right">The right value to pass to the operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T SubtractionOperator<T>(T left, T right)
            => Invoke<T>(Expression.Subtract(Expression.Constant(left), Expression.Constant(right)));

        /// <summary>
        ///     Uses reflection to invoke the unary minus operator for <typeparamref name="T"/> using
        ///     <paramref name="value"/> as the parameter. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="value">The value to pass to operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T UnaryMinusOperator<T>(T value)
            => Invoke<T>(Expression.Negate(Expression.Constant(value)));

        /// <summary>
        ///     Uses reflection to invoke the unary plus operator for <typeparamref name="T"/> using
        ///     <paramref name="value"/> as the parameter. Returns the result of the operation
        ///     or throws an <see cref="System.InvalidOperationException"/> if no such operator is defined.
        /// </summary>
        /// <typeparam name="T">The type for which the operator is defined.</typeparam>
        /// <param name="value">The value to pass to operator.</param>
        /// <returns>The result of invoking the operator.</returns>
        public static T UnaryPlusOperator<T>(T value)
            => Invoke<T>(Expression.UnaryPlus(Expression.Constant(value)));

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
