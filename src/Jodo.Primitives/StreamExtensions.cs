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
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Jodo.Primitives
{
    public static class StreamExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<T>(this Stream stream, T value) where T : struct, IProvider<IBitBuffer<T>>
             => DefaultProvider<T, IBitBuffer<T>>.Instance.Write(value, stream);

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this Stream stream, sbyte value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, sizeof(sbyte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this Stream stream, short value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, sizeof(short));
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this Stream stream, ushort value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this Stream stream, int value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, sizeof(int));
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this Stream stream, uint value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, sizeof(uint));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this Stream stream, long value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, sizeof(long));
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this Stream stream, ulong value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, sizeof(ulong));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this Stream stream, float value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, sizeof(float));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this Stream stream, double value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, sizeof(double));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this Stream stream, decimal value)
        {
            stream.Write(BitOperations.GetBytes(value), 0, sizeof(decimal));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync<T>(this Stream stream, T value) where T : struct, IProvider<IBitBuffer<T>>
            => await DefaultProvider<T, IBitBuffer<T>>.Instance.WriteAsync(value, stream);

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync(this Stream stream, sbyte value)
        {
            await stream.WriteAsync(BitConverter.GetBytes(value), 0, sizeof(sbyte));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync(this Stream stream, short value)
        {
            await stream.WriteAsync(BitConverter.GetBytes(value), 0, sizeof(short));
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync(this Stream stream, ushort value)
        {
            await stream.WriteAsync(BitConverter.GetBytes(value), 0, sizeof(ushort));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync(this Stream stream, int value)
        {
            await stream.WriteAsync(BitConverter.GetBytes(value), 0, sizeof(int));
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync(this Stream stream, uint value)
        {
            await stream.WriteAsync(BitConverter.GetBytes(value), 0, sizeof(uint));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync(this Stream stream, long value)
        {
            await stream.WriteAsync(BitConverter.GetBytes(value), 0, sizeof(long));
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync(this Stream stream, ulong value)
        {
            await stream.WriteAsync(BitConverter.GetBytes(value), 0, sizeof(ulong));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync(this Stream stream, float value)
        {
            await stream.WriteAsync(BitConverter.GetBytes(value), 0, sizeof(float));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync(this Stream stream, double value)
        {
            await stream.WriteAsync(BitConverter.GetBytes(value), 0, sizeof(double));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task WriteAsync(this Stream stream, decimal value)
        {
            await stream.WriteAsync(BitOperations.GetBytes(value), 0, sizeof(decimal));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Read<T>(this Stream stream) where T : struct, IProvider<IBitBuffer<T>>
            => DefaultProvider<T, IBitBuffer<T>>.Instance.Read(stream);

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ReadSByte(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(sbyte)];
            // Using this overload to benefit from parameter validation.
            _ = stream.Read(buffer, 0, sizeof(sbyte));
            return (sbyte)buffer[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ReadInt16(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(short)];
            _ = stream.Read(buffer, 0, sizeof(short));
            return BitConverter.ToInt16(buffer, 0);
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ReadUInt16(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(ushort)];
            _ = stream.Read(buffer, 0, sizeof(ushort));
            return BitConverter.ToUInt16(buffer, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ReadInt32(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(int)];
            _ = stream.Read(buffer, 0, sizeof(int));
            return BitConverter.ToInt32(buffer, 0);
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ReadUInt32(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(uint)];
            _ = stream.Read(buffer, 0, sizeof(uint));
            return BitConverter.ToUInt32(buffer, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ReadInt64(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(long)];
            _ = stream.Read(buffer, 0, sizeof(long));
            return BitConverter.ToInt64(buffer, 0);
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ReadUInt64(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(ulong)];
            _ = stream.Read(buffer, 0, sizeof(ulong));
            return BitConverter.ToUInt64(buffer, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ReadSingle(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(float)];
            _ = stream.Read(buffer, 0, sizeof(float));
            return BitConverter.ToSingle(buffer, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ReadDouble(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(double)];
            _ = stream.Read(buffer, 0, sizeof(double));
            return BitConverter.ToDouble(buffer, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ReadDecimal(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(decimal)];
            _ = stream.Read(buffer, 0, sizeof(decimal));
            return BitOperations.ToDecimal(buffer, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<T> ReadAsync<T>(this Stream stream) where T : struct, IProvider<IBitBuffer<T>>
            => await DefaultProvider<T, IBitBuffer<T>>.Instance.ReadAsync(stream);

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<sbyte> ReadSByteAsync(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(sbyte)];
            // Using this overload to benefit from parameter validation.
            _ = await stream.ReadAsync(buffer, 0, sizeof(sbyte));
            return (sbyte)buffer[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<short> ReadInt16Async(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(short)];
            _ = await stream.ReadAsync(buffer, 0, sizeof(short));
            return BitConverter.ToInt16(buffer, 0);
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<ushort> ReadUInt16Async(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(ushort)];
            _ = await stream.ReadAsync(buffer, 0, sizeof(ushort));
            return BitConverter.ToUInt16(buffer, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<int> ReadInt32Async(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(int)];
            _ = await stream.ReadAsync(buffer, 0, sizeof(int));
            return BitConverter.ToInt32(buffer, 0);
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<uint> ReadUInt32Async(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(uint)];
            _ = await stream.ReadAsync(buffer, 0, sizeof(uint));
            return BitConverter.ToUInt32(buffer, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<long> ReadInt64Async(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(long)];
            _ = await stream.ReadAsync(buffer, 0, sizeof(long));
            return BitConverter.ToInt64(buffer, 0);
        }

        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<ulong> ReadUInt64Async(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(ulong)];
            _ = await stream.ReadAsync(buffer, 0, sizeof(ulong));
            return BitConverter.ToUInt64(buffer, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<float> ReadSingleAsync(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(float)];
            _ = await stream.ReadAsync(buffer, 0, sizeof(float));
            return BitConverter.ToSingle(buffer, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<double> ReadDoubleAsync(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(double)];
            _ = await stream.ReadAsync(buffer, 0, sizeof(double));
            return BitConverter.ToDouble(buffer, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<decimal> ReadDecimalAsync(this Stream stream)
        {
            byte[] buffer = new byte[sizeof(decimal)];
            _ = await stream.ReadAsync(buffer, 0, sizeof(decimal));
            return BitOperations.ToDecimal(buffer, 0);
        }
    }
}
