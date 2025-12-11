using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;

namespace AcParamEditor.Data.Parsers
{
    public class XlsParser : ISpreadSheetParser
    {
        private readonly HSSFWorkbook Workbook;
        private ISheet? CurrentSheet;
        private IRow? CurrentRow;
        private int CurrentSheetIndex;
        private int CurrentRowIndex;
        private int CurrentCellIndex;
        private bool disposedValue;

        public XlsParser(Stream stream)
        {
            Workbook = new HSSFWorkbook(stream);
        }

        #region Open

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XlsParser OpenFile(string path)
            => new XlsParser(File.OpenRead(path));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XlsParser OpenBytes(byte[] bytes)
            => new XlsParser(new MemoryStream(bytes));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XlsParser OpenStream(Stream stream)
            => new XlsParser(stream);

        #endregion

        #region Sheet

        public bool NextSheet([NotNullWhen(true)] out string? sheetName)
        {
            if (CurrentSheetIndex < Workbook.NumberOfSheets)
            {
                CurrentSheet = Workbook.GetSheetAt(CurrentSheetIndex++);
                CurrentRowIndex = 0;
                CurrentCellIndex = 0;
                CurrentRow = null;
                sheetName = CurrentSheet.SheetName ?? string.Empty;
                return true;
            }

            sheetName = null;
            return false;
        }

        #endregion

        #region Row

        public bool NextRow()
        {
            if (CurrentSheet == null)
                throw new InvalidOperationException("A sheet must be opened before opening a row.");

            var row = CurrentSheet.GetRow(CurrentRowIndex);
            if (row == null)
                return false;

            CurrentRow = row;
            CurrentRowIndex++;
            CurrentCellIndex = 0;
            return true;
        }

        #endregion

        #region Cell

        private bool TryMoveNextCell([NotNullWhen(true)] out ICell? cell)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be opened before opening a cell.");

            cell = CurrentRow.GetCell(CurrentCellIndex);
            if (cell == null)
            {
                return false;
            }

            CurrentCellIndex++;
            return true;
        }

        public bool NextCell([NotNullWhen(true)] out string? value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = null;
                return false;
            }

            switch (cell.CellType)
            {
                case CellType.String:
                    value = cell.StringCellValue ?? string.Empty;
                    return true;
                case CellType.Numeric:
                    value = cell.NumericCellValue.ToString();
                    return true;
                case CellType.Boolean:
                    value = cell.BooleanCellValue.ToString();
                    return true;
                case CellType.Error:
                case CellType.Unknown:
                case CellType.Formula:
                case CellType.Blank:
                default:
                    value = string.Empty;
                    return true;
            }
        }

        public bool NextCell([NotNullWhen(true)] out sbyte value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = (sbyte)cell.NumericCellValue;
            if (value != cell.NumericCellValue)
            {
                value = default;
                return false;
            }

            return true;
        }

        public bool NextCell([NotNullWhen(true)] out byte value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = (byte)cell.NumericCellValue;
            if (value != cell.NumericCellValue)
            {
                value = default;
                return false;
            }

            return true;
        }

        public bool NextCell([NotNullWhen(true)] out short value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = (short)cell.NumericCellValue;
            if (value != cell.NumericCellValue)
            {
                value = default;
                return false;
            }

            return true;
        }

        public bool NextCell([NotNullWhen(true)] out ushort value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = (ushort)cell.NumericCellValue;
            if (value != cell.NumericCellValue)
            {
                value = default;
                return false;
            }

            return true;
        }

        public bool NextCell([NotNullWhen(true)] out int value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = (int)cell.NumericCellValue;
            if (value != cell.NumericCellValue)
            {
                value = default;
                return false;
            }

            return true;
        }

        public bool NextCell([NotNullWhen(true)] out uint value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = (uint)cell.NumericCellValue;
            if (value != cell.NumericCellValue)
            {
                value = default;
                return false;
            }

            return true;
        }

        public bool NextCell([NotNullWhen(true)] out long value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = (long)cell.NumericCellValue;
            if (value != cell.NumericCellValue)
            {
                value = default;
                return false;
            }

            return true;
        }

        public bool NextCell([NotNullWhen(true)] out ulong value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = (ulong)cell.NumericCellValue;
            if (value != cell.NumericCellValue)
            {
                value = default;
                return false;
            }

            return true;
        }

        public bool NextCell([NotNullWhen(true)] out Half value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = (Half)cell.NumericCellValue;
            if ((double)value != cell.NumericCellValue)
            {
                value = default;
                return false;
            }

            return true;
        }

        public bool NextCell([NotNullWhen(true)] out float value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = (float)cell.NumericCellValue;
            if (value != cell.NumericCellValue)
            {
                value = default;
                return false;
            }

            return true;
        }

        public bool NextCell([NotNullWhen(true)] out double value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = cell.NumericCellValue;
            return true;
        }

        public bool NextCell([NotNullWhen(true)] out decimal value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Numeric)
            {
                value = default;
                return false;
            }

            value = (decimal)cell.NumericCellValue;
            return true;
        }

        public bool NextCell([NotNullWhen(true)] out bool value)
        {
            if (!TryMoveNextCell(out ICell? cell))
            {
                value = default;
                return false;
            }

            if (cell.CellType != CellType.Boolean)
            {
                value = default;
                return false;
            }

            value = cell.BooleanCellValue;
            return true;
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Workbook.Dispose();
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
