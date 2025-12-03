using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace AcParamEditor.Text
{
    public class TextBuilder : TextWriter
    {
        private readonly StringBuilder Buffer;
        public override Encoding Encoding
            => Encoding.Default;

        public TextBuilder()
        {
            Buffer = new StringBuilder();
        }

        public TextBuilder(string? buffer)
        {
            Buffer = new StringBuilder(buffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(object? value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(char value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(int value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(uint value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(long value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(ulong value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(float value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(double value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(decimal value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(bool value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(string? value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(StringBuilder? value)
            => Buffer.Append(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(object? value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(char value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(int value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(uint value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(long value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(ulong value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(float value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(double value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(decimal value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(bool value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(string? value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(StringBuilder? value)
        {
            Buffer.Append(value);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(char[] buffer, int index, int count)
            => Buffer.Append(buffer, index, count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(char[] buffer, int index, int count)
        {
            Buffer.Append(buffer, index, count);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(char[]? buffer)
            => Buffer.Append(buffer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(char[]? buffer)
        {
            Buffer.Append(buffer);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine()
            => Buffer.Append(NewLine);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Write(ReadOnlySpan<char> buffer)
            => Buffer.Append(buffer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void WriteLine(ReadOnlySpan<char> buffer)
        {
            Buffer.Append(buffer);
            Buffer.Append(NewLine);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
            => Buffer.ToString();
    }
}
