using AcParamEditor.Data.Configs;
using SoulsFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace AcParamEditor.Data
{
    public class ParamExporter : IDisposable
    {
        private readonly ISpreadSheetBuilder Builder;
        private readonly bool UseInternalNames;
        private readonly ParamWorkbookConfig Config;
        private readonly HashSet<string> UsedSheetNames;
        private bool disposedValue;

        public string Extension
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Builder.Extension;
        }

        public ParamExporter(ISpreadSheetBuilder tableBuilder, bool useInternalNames)
        {
            Builder = tableBuilder;
            UseInternalNames = useInternalNames;
            UsedSheetNames = [];
            Config = new ParamWorkbookConfig();
        }

        private string GetSheetName(string name)
        {
            int copyIndex = 1;
            string original = name;
            while (!UsedSheetNames.Add(name))
            {
                name = $"{original} ({copyIndex++})";
            }

            return name;
        }

        public void AddParam(string name, string extension, PARAM param)
        {
            string sheetName = GetSheetName(name);
            Builder.NextSheet(sheetName);

            // Header
            Builder.NextRow();
            Builder.NextCell("Row ID");
            Builder.NextCell("Row Name");

            foreach (var field in param.AppliedParamdef.Fields)
            {
                string columnName = field.DisplayName;
                if (UseInternalNames)
                    columnName = field.InternalName;

                Builder.NextCell(columnName);
            }

            // Entries
            foreach (var row in param.Rows)
            {
                Builder.NextRow();

                Builder.NextCell(row.ID);
                Builder.NextCell(row.Name);
                foreach (var cell in row.Cells)
                {
                    switch (cell.DisplayType)
                    {
                        case PARAMDEF.DefType.s8:
                            if (cell.Value is not sbyte s8)
                                s8 = default;
                            Builder.NextCell(s8);
                            break;
                        case PARAMDEF.DefType.u8:
                            if (cell.ArrayLength > 1)
                            {
                                Builder.NextCell(string.Empty);
                                break;
                            }

                            if (cell.Value is not byte u8)
                                u8 = default;
                            Builder.NextCell(u8);
                            break;
                        case PARAMDEF.DefType.s16:
                            if (cell.Value is not short s16)
                                s16 = default;
                            Builder.NextCell(s16);
                            break;
                        case PARAMDEF.DefType.u16:
                            if (cell.Value is not ushort u16)
                                u16 = default;
                            Builder.NextCell(u16);
                            break;
                        case PARAMDEF.DefType.b32:
                        case PARAMDEF.DefType.s32:
                            if (cell.Value is not int s32)
                                s32 = default;
                            Builder.NextCell(s32);
                            break;
                        case PARAMDEF.DefType.u32:
                            if (cell.Value is not uint u32)
                                u32 = default;
                            Builder.NextCell(u32);
                            break;
                        case PARAMDEF.DefType.angle32:
                        case PARAMDEF.DefType.f32:
                            if (cell.Value is not float f32)
                                f32 = default;
                            Builder.NextCell(f32);
                            break;
                        case PARAMDEF.DefType.f64:
                            if (cell.Value is not double f64)
                                f64 = default;
                            Builder.NextCell(f64);
                            break;
                        case PARAMDEF.DefType.dummy8:
                            Builder.NextCell(string.Empty);
                            break;
                        case PARAMDEF.DefType.fixstrW:
                        case PARAMDEF.DefType.fixstr:
                            if (cell.Value is not string fixstr)
                                fixstr = string.Empty;

                            if (fixstr.Length > cell.ArrayLength)
                                fixstr = fixstr[..cell.ArrayLength];

                            Builder.NextCell(fixstr);
                            break;
                        default:
                            throw new NotSupportedException($"Unknown {nameof(PARAMDEF.DefType)}: \"{cell.DisplayType}\"");
                    }
                }
            }

            Config.Params.Add(new ParamWorkbookConfig.ParamSheet(sheetName, name, extension, param.ParamType)
            {
                BigEndian = param.BigEndian,
                Flags1 = param.Format2D,
                Flags2 = param.Format2E,
                ParamdefFormatVersion = param.ParamdefFormatVersion,
                ParamdefDataVersion = (byte)param.ParamdefDataVersion,
                Unk06 = param.Unk06,
                HeaderlessRows = param.HeaderlessRows,
                NamelessRows = param.UnnamedRows
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ParamWorkbookConfig GetConfig()
            => Config;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Export(string path)
            => Builder.Write(path);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Export(Stream stream)
            => Builder.Write(stream);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] Export()
            => Builder.Write();

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Builder.Dispose();
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
