using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace AcParamEditor.Data.Parsers
{
    public class TsvParser : ISpreadSheetParser
    {
        private readonly StreamReader Buffer;
        private readonly CsvReader Reader;
        private readonly string Name;
        private bool LoadedSheet;
        private int CurrentCellIndex;
        private bool disposedValue;

        public TsvParser(Stream stream, Encoding encoding, string name = "", bool leaveOpen = false)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = encoding,
                Delimiter = "\t",
                MissingFieldFound = null
            };

            Buffer = new StreamReader(stream, encoding, leaveOpen: leaveOpen);
            Reader = new CsvReader(Buffer, config, false);
            Name = name;
        }

        #region Open

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TsvParser OpenFile(string path, Encoding encoding)
            => new TsvParser(File.OpenRead(path), encoding, Path.GetFileNameWithoutExtension(path), false);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TsvParser OpenFile(string path, Encoding encoding, string name)
            => new TsvParser(File.OpenRead(path), encoding, name, false);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TsvParser OpenBytes(byte[] bytes, Encoding encoding, string name = "")
            => new TsvParser(new MemoryStream(bytes), encoding, name, false);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TsvParser OpenStream(Stream stream, Encoding encoding, string name = "", bool leaveOpen = false)
            => new TsvParser(stream, encoding, name, leaveOpen);

        #endregion

        #region Sheet

        // Not supported for TSV
        public bool NextSheet([NotNullWhen(true)] out string? sheetName)
        {
            if (LoadedSheet)
            {
                sheetName = null;
                return false;
            }

            LoadedSheet = true;
            sheetName = Name;
            return true;
        }

        #endregion

        #region Row

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextRow()
        {
            bool result = Reader.Read();
            if (result)
            {
                CurrentCellIndex = 0;
            }

            return result;
        }

        #endregion

        #region Cell

        public bool NextCell([NotNullWhen(true)] out string? value)
        {
            value = Reader.GetField(CurrentCellIndex);
            if (value == null)
            {
                return false;
            }

            CurrentCellIndex++;
            return true;
        }

        public bool NextCell([NotNullWhen(true)] out sbyte value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return sbyte.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out byte value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return byte.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out short value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return short.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out ushort value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return ushort.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out int value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return int.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out uint value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return uint.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out long value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return long.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out ulong value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return ulong.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out Half value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return Half.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out float value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return float.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out double value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return double.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out decimal value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return decimal.TryParse(strValue, out value);
        }

        public bool NextCell([NotNullWhen(true)] out bool value)
        {
            if (!NextCell(out string? strValue))
            {
                value = default;
                return false;
            }

            return bool.TryParse(strValue, out value);
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Reader.Dispose();
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
