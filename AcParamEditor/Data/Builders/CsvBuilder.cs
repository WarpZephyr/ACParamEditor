using AcParamEditor.Text;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace AcParamEditor.Data.Builders
{
    public class CsvBuilder : ISpreadSheetBuilder
    {
        public string Extension
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => "csv";
        }

        private readonly Encoding Encoding;
        private readonly TextBuilder Buffer;
        private readonly CsvWriter Writer;
        private bool StartedRows;
        private bool disposedValue;

        public CsvBuilder(Encoding encoding)
        {
            Encoding = encoding;
            Buffer = new TextBuilder();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = encoding,
                MissingFieldFound = null
            };

            Writer = new CsvWriter(Buffer, config, true);
        }

        public CsvBuilder() : this(Encoding.UTF8) { }

        #region Sheet

        // Not supported for CSV
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextSheet(string name) { }

        #endregion

        #region Row

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextRow()
        {
            if (!StartedRows)
            {
                StartedRows = true;
                return;
            }

            Writer.NextRecord();
        }

        #endregion

        #region Cell

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(string? value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(sbyte value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(byte value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(short value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(ushort value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(int value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(uint value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(long value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(ulong value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(Half value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(float value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(double value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(decimal value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(bool value)
            => Writer.WriteField(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextCell(object? value)
            => Writer.WriteField(value);

        #endregion

        #region Write

        public void Write(string path)
        {
            Writer.Flush();
            File.WriteAllText(path, Buffer.ToString(), Encoding);
        }

        public void Write(Stream stream)
        {
            Writer.Flush();
            using var tw = new StreamWriter(stream, Encoding);
            tw.Write(Buffer.ToString());
        }

        public byte[] Write()
        {
            Writer.Flush();
            return Encoding.GetBytes(Buffer.ToString());
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Writer.Dispose();
                    Buffer.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
