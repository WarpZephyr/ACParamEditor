using System;
using System.Diagnostics.CodeAnalysis;

namespace AcParamEditor.Data
{
    public interface ISpreadSheetParser : IDisposable
    {
        public bool NextSheet([NotNullWhen(true)] out string? sheetName);
        public bool NextRow();
        public bool NextCell([NotNullWhen(true)] out string? value);
        public bool NextCell([NotNullWhen(true)] out sbyte value);
        public bool NextCell([NotNullWhen(true)] out byte value);
        public bool NextCell([NotNullWhen(true)] out short value);
        public bool NextCell([NotNullWhen(true)] out ushort value);
        public bool NextCell([NotNullWhen(true)] out int value);
        public bool NextCell([NotNullWhen(true)] out uint value);
        public bool NextCell([NotNullWhen(true)] out long value);
        public bool NextCell([NotNullWhen(true)] out ulong value);
        public bool NextCell([NotNullWhen(true)] out Half value);
        public bool NextCell([NotNullWhen(true)] out float value);
        public bool NextCell([NotNullWhen(true)] out double value);
        public bool NextCell([NotNullWhen(true)] out decimal value);
        public bool NextCell([NotNullWhen(true)] out bool value);
    }
}
