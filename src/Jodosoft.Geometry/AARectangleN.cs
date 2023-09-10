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

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Jodosoft.Numerics;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Geometry
{
    /// <summary>
    /// Represents an axis-aligned (non-rotated) rectangle defined by its center and dimensions.
    /// </summary>
    /// <typeparam name="TNumeric">The type of number used to specify the center and dimensions of the rectangle.</typeparam>
    /// <seealso cref="AARectangleN"/>
    /// <seealso cref="RectangleN{TNumeric}"/>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct AARectangleN<TNumeric> :
            IEquatable<AARectangleN<TNumeric>>,
            IFormattable,
            IProvider<IBinaryIO<AARectangleN<TNumeric>>>,
            IProvider<IVariantRandom<AARectangleN<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly Vector2N<TNumeric> Center;
        public readonly Vector2N<TNumeric> Dimensions;

        public TNumeric Height => Dimensions.Y;
        public TNumeric Width => Dimensions.X;

        public AARectangleN(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions)
        {
            Center = center;
            Dimensions = dimensions;
        }

        public AARectangleN(TNumeric centerX, TNumeric centerY, TNumeric width, TNumeric height)
        {
            Center = new Vector2N<TNumeric>(centerX, centerY);
            Dimensions = new Vector2N<TNumeric>(width, height);
        }

        private AARectangleN(SerializationInfo info, StreamingContext context) : this(
            (Vector2N<TNumeric>)(info.GetValue(nameof(Center), typeof(Vector2N<TNumeric>)) ?? throw new InvalidOperationException()),
            (Vector2N<TNumeric>)(info.GetValue(nameof(Dimensions), typeof(Vector2N<TNumeric>)) ?? throw new InvalidOperationException()))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2N<TNumeric>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2N<TNumeric>));
        }

        public TNumeric GetArea() => MathN.Abs(Dimensions.X.Multiply(Dimensions.Y));

        public AARectangleN<TNumeric> Translate(Vector2N<TNumeric> delta) => new AARectangleN<TNumeric>(Center + delta, Dimensions);

        public bool Contains(Vector2N<TNumeric> point) =>
            point.X.IsGreaterThanOrEqualTo(this.GetLeft()) &&
            point.X.IsLessThanOrEqualTo(this.GetRight()) &&
            point.Y.IsGreaterThanOrEqualTo(this.GetBottom()) &&
            point.Y.IsLessThanOrEqualTo(this.GetTop());

        public bool Contains(AARectangleN<TNumeric> other) =>
           this.GetLeft().IsLessThanOrEqualTo(other.GetLeft()) &&
           this.GetRight().IsGreaterThanOrEqualTo(other.GetRight()) &&
           this.GetBottom().IsLessThanOrEqualTo(other.GetBottom()) &&
           this.GetTop().IsGreaterThanOrEqualTo(other.GetTop());

        public bool IntersectsWith(AARectangleN<TNumeric> other) =>
           this.GetLeft().IsLessThan(other.GetRight()) &&
           this.GetRight().IsGreaterThan(other.GetLeft()) &&
           this.GetBottom().IsLessThan(other.GetTop()) &&
           this.GetTop().IsGreaterThan(other.GetBottom());

        public AARectangleN<TOther> Convert<TOther>(Func<TNumeric, TOther> convert) where TOther : struct, INumeric<TOther> => new AARectangleN<TOther>(convert(Center.X), convert(Center.Y), convert(Dimensions.X), convert(Dimensions.Y));
        public bool Equals(AARectangleN<TNumeric> other) => Center.Equals(other.Center) && Dimensions.Equals(other.Dimensions);
        public override bool Equals(object? obj) => obj is AARectangleN<TNumeric> fix && Equals(fix);
        public override int GetHashCode() => HashCodeShim.Combine(Center, Dimensions);
        public override string ToString() => $"<X:{Center.X}, Y:{Center.Y}, W:{Dimensions.X}, H:{Dimensions.Y}>";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"<X:{Center.X.ToString(format, formatProvider)}, Y:{Center.Y.ToString(format, formatProvider)}, W:{Dimensions.X.ToString(format, formatProvider)}, H:{Dimensions.Y.ToString(format, formatProvider)}>";

        public static bool operator ==(AARectangleN<TNumeric> left, AARectangleN<TNumeric> right) => left.Equals(right);
        public static bool operator !=(AARectangleN<TNumeric> left, AARectangleN<TNumeric> right) => !(left == right);

        IBinaryIO<AARectangleN<TNumeric>> IProvider<IBinaryIO<AARectangleN<TNumeric>>>.GetInstance() => Utilities.Instance;
        IVariantRandom<AARectangleN<TNumeric>> IProvider<IVariantRandom<AARectangleN<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBinaryIO<AARectangleN<TNumeric>>,
           IVariantRandom<AARectangleN<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<AARectangleN<TNumeric>>.Write(BinaryWriter writer, AARectangleN<TNumeric> value)
            {
                writer.Write(value.Center);
                writer.Write(value.Dimensions);
            }

            AARectangleN<TNumeric> IBinaryIO<AARectangleN<TNumeric>>.Read(BinaryReader reader)
            {
                return new AARectangleN<TNumeric>(
                    reader.Read<Vector2N<TNumeric>>(),
                    reader.Read<Vector2N<TNumeric>>());
            }

            AARectangleN<TNumeric> IVariantRandom<AARectangleN<TNumeric>>.Generate(Random random, Variants variants)
            {
                return new AARectangleN<TNumeric>(
                    random.NextVariant<Vector2N<TNumeric>>(variants),
                    random.NextVariant<Vector2N<TNumeric>>(variants));
            }
        }
    }

    /// <summary>
    /// Provides methods for creating instances of <see cref="AARectangleN{TNumeric}"/>.
    /// </summary>
    public static class AARectangleN
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> Between<TNumeric>(Vector2N<TNumeric> point1, Vector2N<TNumeric> point2) where TNumeric : struct, INumeric<TNumeric>
        {
            Vector2N<TNumeric> dimensions = point2.Subtract(point1);
            return new AARectangleN<TNumeric>(point1.Add(dimensions.Half()), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> FromCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangleN<TNumeric>(center, dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> FromBottomLeft<TNumeric>(Vector2N<TNumeric> bottomLeft, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangleN<TNumeric>(GetCenterFromBottomLeft(bottomLeft, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> FromBottomCenter<TNumeric>(Vector2N<TNumeric> bottomCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangleN<TNumeric>(GetCenterFromBottomCenter(bottomCenter, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> FromBottomRight<TNumeric>(Vector2N<TNumeric> bottomRight, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangleN<TNumeric>(GetCenterFromBottomRight(bottomRight, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> FromLeftCenter<TNumeric>(Vector2N<TNumeric> leftCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangleN<TNumeric>(GetCenterFromLeftCenter(leftCenter, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> FromRightCenter<TNumeric>(Vector2N<TNumeric> rightCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangleN<TNumeric>(GetCenterFromRightCenter(rightCenter, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> FromTopCenter<TNumeric>(Vector2N<TNumeric> topCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangleN<TNumeric>(GetCenterFromTopCenter(topCenter, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> FromTopLeft<TNumeric>(Vector2N<TNumeric> topLeft, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangleN<TNumeric>(GetCenterFromTopLeft(topLeft, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangleN<TNumeric> FromTopRight<TNumeric>(Vector2N<TNumeric> topRight, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangleN<TNumeric>(GetCenterFromTopRight(topRight, dimensions), dimensions);
        }

        public static AARectangleN<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            string[] parts = StringUtilities.ParseVectorParts(s.Trim());
            if (parts.Length == 4)
                return new AARectangleN<TNumeric>(
                    Numeric.Parse<TNumeric>(parts[0].Replace("X:", string.Empty).Trim(), style, provider),
                    Numeric.Parse<TNumeric>(parts[1].Replace("Y:", string.Empty).Trim(), style, provider),
                    Numeric.Parse<TNumeric>(parts[2].Replace("W:", string.Empty).Trim(), style, provider),
                    Numeric.Parse<TNumeric>(parts[3].Replace("H:", string.Empty).Trim(), style, provider));
            else throw new FormatException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetBottom<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return center.Y.Subtract(dimensions.Y.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetLeft<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return center.X.Subtract(dimensions.X.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetRight<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            // When subtracting, whole dimensions must be used to avoid errors caused by truncated integer division.
            return center.X.Subtract(dimensions.X.Half()).Add(dimensions.X);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetTop<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            // When subtracting, whole dimensions must be used to avoid errors caused by truncated integer division.
            return center.Y.Subtract(dimensions.Y.Half()).Add(dimensions.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetBottomCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(center.X, GetBottom(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetBottomLeft<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetLeft(center, dimensions), GetBottom(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetBottomRight<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetRight(center, dimensions), GetBottom(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetLeftCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetLeft(center, dimensions), center.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetRightCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetRight(center, dimensions), center.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetTopCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(center.X, GetTop(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetTopLeft<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetLeft(center, dimensions), GetTop(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetTopRight<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetRight(center, dimensions), GetTop(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetCenterYFromBottom<TNumeric>(Vector2N<TNumeric> bottom, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return bottom.Y.Add(dimensions.Y.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetCenterYFromTop<TNumeric>(Vector2N<TNumeric> top, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            // When subtracting, whole dimensions must be used to avoid errors caused by truncated integer division.
            return top.Y.Subtract(dimensions.Y).Add(dimensions.Y.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetCenterXFromLeft<TNumeric>(Vector2N<TNumeric> left, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return left.X.Add(dimensions.X.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetCenterXFromRight<TNumeric>(Vector2N<TNumeric> right, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return right.X.Subtract(dimensions.X).Add(dimensions.X.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromBottomCenter<TNumeric>(Vector2N<TNumeric> bottomCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(bottomCenter.X, GetCenterYFromBottom(bottomCenter, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromBottomLeft<TNumeric>(Vector2N<TNumeric> bottomLeft, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromLeft(bottomLeft, dimensions), GetCenterYFromBottom(bottomLeft, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromBottomRight<TNumeric>(Vector2N<TNumeric> bottomRight, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromRight(bottomRight, dimensions), GetCenterYFromBottom(bottomRight, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromLeftCenter<TNumeric>(Vector2N<TNumeric> leftCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromLeft(leftCenter, dimensions), leftCenter.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromRightCenter<TNumeric>(Vector2N<TNumeric> rightCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromRight(rightCenter, dimensions), rightCenter.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromTopCenter<TNumeric>(Vector2N<TNumeric> topCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(topCenter.X, GetCenterYFromTop(topCenter, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromTopLeft<TNumeric>(Vector2N<TNumeric> topLeft, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromLeft(topLeft, dimensions), GetCenterYFromTop(topLeft, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromTopRight<TNumeric>(Vector2N<TNumeric> topRight, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromRight(topRight, dimensions), GetCenterYFromTop(topRight, dimensions));
        }
    }
}
