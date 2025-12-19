using SoulsFormats;
using System;
using System.Collections.Generic;
using System.IO;

namespace AcParamEditor
{
    internal static class TentativeParamTypeMap
    {
        public static bool LoadCsv(Dictionary<string, ParamDefInfo> defMap, Dictionary<string, PARAMDEF> rawDefMap, string path, out int loaded, out int total)
        {
            loaded = 0;
            total = 0;
            if (!File.Exists(path))
            {
                return false;
            }

            var alreadyMappedTypes = new HashSet<string>();
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                string columnsLine = lines[i];
                string[] columns = columnsLine.Split(',', StringSplitOptions.TrimEntries);
                if (columns.Length < 2)
                    continue;

                bool alreadyMapped = true;
                string name = columns[0];
                string type = columns[1];
                if (alreadyMappedTypes.Add(type))
                {
                    // Count this towards the total possible entries if it isn't a duplicate
                    // While still allowing overwriting previous mappings in the list
                    total++;
                    alreadyMapped = false;
                }

                if (defMap.TryGetValue(type, out ParamDefInfo? def))
                {
                    defMap.Add(name, def);
                    rawDefMap.Add(name, def.Def);

                    if (!alreadyMapped)
                    {
                        loaded++; // Count this towards the loaded entries if it isn't a duplicate
                    }
                }
            }

            return true;
        }
    }
}
