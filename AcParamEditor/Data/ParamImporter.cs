using AcParamEditor.Data.Configs;
using SoulsFormats;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AcParamEditor.Data
{
    public class ParamImporter : IDisposable
    {
        private readonly ISpreadSheetParser Parser;
        private readonly ParamWorkbookConfig Config;
        private readonly Dictionary<string, PARAMDEF> DefMap;
        private string? CurrentSheetName;
        private bool disposedValue;

        public ParamImporter(ISpreadSheetParser parser, ParamWorkbookConfig config, Dictionary<string, PARAMDEF> defmap)
        {
            Parser = parser;
            Config = config;
            DefMap = defmap;
            CurrentSheetName = null;
        }

        private bool TryGetSheetConfig(string sheetName, [NotNullWhen(true)] out ParamWorkbookConfig.ParamSheet? sheet)
        {
            foreach (var param in Config.Params)
            {
                if (param.SheetName.Equals(sheetName, StringComparison.InvariantCultureIgnoreCase))
                {
                    sheet = param;
                    return true;
                }
            }

            sheet = null;
            return false;
        }

        public bool NextSheet([NotNullWhen(true)] out string? sheetName)
        {
            if (Parser.NextSheet(out sheetName))
            {
                CurrentSheetName = sheetName;
                return true;
            }

            return false;
        }

        public bool NextParam([NotNullWhen(true)] out ImportedParam? import)
        {
            if (CurrentSheetName == null)
            {
                throw new InvalidOperationException($"No sheet has been read yet, please call {nameof(NextSheet)} first.");
            }

            string sheetName = CurrentSheetName;
            if (!TryGetSheetConfig(sheetName, out ParamWorkbookConfig.ParamSheet? sheetConfig))
            {
                import = null;
                return false;
            }

            string? paramType = sheetConfig.ParamType;
            if (string.IsNullOrEmpty(paramType))
            {
                paramType = sheetConfig.Name;
            }

            if (!DefMap.TryGetValue(paramType, out PARAMDEF? def))
            {
                import = null;
                return false;
            }

            // Skip header row
            if (!Parser.NextRow())
            {
                import = null;
                return false;
            }

            PARAM param = new PARAM()
            {
                ParamType = sheetConfig.ParamType,
                BigEndian = sheetConfig.BigEndian,
                Format2D = sheetConfig.Flags1,
                Format2E = sheetConfig.Flags2,
                ParamdefFormatVersion = sheetConfig.ParamdefFormatVersion,
                ParamdefDataVersion = sheetConfig.ParamdefDataVersion,
                Unk06 = sheetConfig.Unk06,
                HeaderlessRows = sheetConfig.HeaderlessRows,
                UnnamedRows = sheetConfig.NamelessRows,
                Rows = []
            };

            param.ApplyParamdefSomewhatCarefully(def);

            // Helper function for getting unique row ids
            int maxRowId = -1;
            var usedIds = new HashSet<int>();
            int GetUniqueRowId(int rowId)
            {
                if (usedIds.Contains(rowId))
                {
                    rowId = ++maxRowId;
                }

                if (rowId > maxRowId)
                {
                    maxRowId = rowId;
                }

                usedIds.Add(rowId);
                return rowId;
            }

            while (Parser.NextRow())
            {
                if (!Parser.NextCell(out int rowId))
                {
                    rowId = -1;
                }

                rowId = GetUniqueRowId(rowId);
                if (!Parser.NextCell(out string? rowName))
                {
                    rowName = string.Empty;
                }

                var row = new PARAM.Row(rowId, rowName, def);
                foreach (var cell in row.Cells)
                {
                    switch (cell.DisplayType)
                    {
                        case PARAMDEF.DefType.s8:
                            if (Parser.NextCell(out sbyte sbyteValue))
                                cell.Value = sbyteValue;
                            break;
                        case PARAMDEF.DefType.u8:
                            if (Parser.NextCell(out byte byteValue))
                                cell.Value = byteValue;
                            break;
                        case PARAMDEF.DefType.s16:
                            if (Parser.NextCell(out short shortValue))
                                cell.Value = shortValue;
                            break;
                        case PARAMDEF.DefType.u16:
                            if (Parser.NextCell(out ushort ushortValue))
                                cell.Value = ushortValue;
                            break;
                        case PARAMDEF.DefType.s32:
                            if (Parser.NextCell(out int intValue))
                                cell.Value = intValue;
                            break;
                        case PARAMDEF.DefType.u32:
                            if (Parser.NextCell(out uint uintValue))
                                cell.Value = uintValue;
                            break;
                        case PARAMDEF.DefType.b32:
                            if (Parser.NextCell(out string? bintStrValue))
                            {
                                if (int.TryParse(bintStrValue, out int bintValue))
                                {
                                    cell.Value = bintValue;
                                }
                                else if (bool.TryParse(bintStrValue, out bool bValue))
                                {
                                    cell.Value = bValue ? 1 : 0;
                                }
                            }
                            break;
                        case PARAMDEF.DefType.angle32:
                        case PARAMDEF.DefType.f32:
                            if (Parser.NextCell(out float floatValue))
                                cell.Value = floatValue;
                            break;
                        case PARAMDEF.DefType.f64:
                            if (Parser.NextCell(out double doubleValue))
                                cell.Value = doubleValue;
                            break;
                        case PARAMDEF.DefType.fixstr:
                        case PARAMDEF.DefType.fixstrW:
                            if (Parser.NextCell(out string? fixStr))
                            {
                                if (fixStr.Length > cell.ArrayLength)
                                    fixStr = fixStr[..cell.ArrayLength];

                                cell.Value = fixStr;
                            }
                            break;
                        case PARAMDEF.DefType.dummy8:
                        default:
                            // Skip this
                            break;
                    }
                }

                param.Rows.Add(row);
            }

            import = new ImportedParam(param, sheetConfig.Name, sheetConfig.Extension);
            return true;
        }

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Parser.Dispose();
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

        #region Imported Param

        public record ImportedParam(PARAM Param, string Name, string Extension);

        #endregion
    }
}
