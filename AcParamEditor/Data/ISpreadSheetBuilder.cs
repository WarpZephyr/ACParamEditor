using System;
using System.IO;

namespace AcParamEditor.Data
{
    public interface ISpreadSheetBuilder : IDisposable
    {
        public string Extension { get; }

        public void NextSheet(string name);

        public void NextRow();

        public void NextCell(string? value);
        public void NextCell(sbyte value);
        public void NextCell(byte value);
        public void NextCell(short value);
        public void NextCell(ushort value);
        public void NextCell(int value);
        public void NextCell(uint value);
        public void NextCell(long value);
        public void NextCell(ulong value);
        public void NextCell(Half value);
        public void NextCell(float value);
        public void NextCell(double value);
        public void NextCell(decimal value);
        public void NextCell(bool value);
        public void NextCell(object? value);

        public void Write(string path);
        public void Write(Stream stream);
        public byte[] Write();
    }
}
