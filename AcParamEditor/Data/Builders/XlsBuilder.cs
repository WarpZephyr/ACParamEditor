using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace AcParamEditor.Data.Builders
{
    public class XlsBuilder : ISpreadSheetBuilder
    {
        public string Extension
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => "xls";
        }

        private readonly HSSFWorkbook Workbook;
        private ISheet? CurrentSheet;
        private IRow? CurrentRow;
        private int CurrentRowIndex;
        private int CurrentCellIndex;
        private bool disposedValue;

        public XlsBuilder()
        {
            Workbook = new HSSFWorkbook();
        }

        public XlsBuilder(string sheetName)
        {
            Workbook = new HSSFWorkbook();
            CurrentSheet = Workbook.CreateSheet(sheetName);
        }

        #region Sheet

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextSheet(string name)
        {
            CurrentSheet = Workbook.CreateSheet(name);
            CurrentRowIndex = 0;
            CurrentCellIndex = 0;
            CurrentRow = null;
        }

        #endregion

        #region Row

        public void NextRow()
        {
            if (CurrentSheet == null)
                throw new InvalidOperationException("A sheet must be made before creating a row.");

            CurrentRow = CurrentSheet.CreateRow(CurrentRowIndex++);
            CurrentCellIndex = 0;
        }

        #endregion

        #region Cell

        public void NextCell(string? value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.String);
            cell.SetCellValue(value ?? string.Empty);
        }

        public void NextCell(sbyte value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue(value);
        }

        public void NextCell(byte value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue(value);
        }

        public void NextCell(short value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue(value);
        }

        public void NextCell(ushort value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue(value);
        }

        public void NextCell(int value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue(value);
        }

        public void NextCell(uint value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue(value);
        }

        public void NextCell(long value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue(value);
        }

        public void NextCell(ulong value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue(value);
        }

        public void NextCell(Half value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue((double)value);
        }

        public void NextCell(float value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");


            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue(value);
        }

        public void NextCell(double value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue(value);
        }

        public void NextCell(decimal value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Numeric);
            cell.SetCellValue((double)value);
        }

        public void NextCell(bool value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.Boolean);
            cell.SetCellValue(value);
        }

        public void NextCell(object? value)
        {
            if (CurrentRow == null)
                throw new InvalidOperationException("A row must be made before creating a cell.");

            var cell = CurrentRow.CreateCell(CurrentCellIndex++, CellType.String);
            cell.SetCellValue(value?.ToString() ?? string.Empty);
        }

        #endregion

        #region Write

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(string path)
        {
            using var fs = File.OpenWrite(path);
            Workbook.Write(fs, false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write(Stream stream)
            => Workbook.Write(stream, true);

        public byte[] Write()
        {
            using var ms = new MemoryStream();
            Workbook.Write(ms, true);
            return ms.ToArray();
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
