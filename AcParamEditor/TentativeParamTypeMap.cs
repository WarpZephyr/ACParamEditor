using SoulsFormats;
using System;
using System.Collections.Generic;
using System.IO;

namespace AcParamEditor
{
    internal static class TentativeParamTypeMap
    {
        public static void LoadCsv(Dictionary<string, ParamDefInfo> defMap, Dictionary<string, PARAMDEF> rawDefMap, string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string columnsLine = lines[i];
                string[] columns = columnsLine.Split(',', StringSplitOptions.TrimEntries);
                if (columns.Length < 2)
                    continue;

                string name = columns[0];
                string type = columns[1];
                if (defMap.TryGetValue(type, out ParamDefInfo? def))
                {
                    defMap.Add(name, def);
                    rawDefMap.Add(name, def.Def);
                }
            }
        }
    }
}
