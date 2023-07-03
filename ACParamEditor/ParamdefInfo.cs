using SoulsFormats;

namespace ACParamEditor
{
    /// <summary>
    /// A class for storing information about loaded param defs.
    /// </summary>
    public class ParamdefInfo
    {
        /// <summary>
        /// The name of the param def.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The full file path to the param def.
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Type ParamType of the param def.
        /// </summary>
        public string Type { get => Def.ParamType; set => Def.ParamType = value; }

        /// <summary>
        /// The format version of the def.
        /// </summary>
        public short FormatVersion { get => Def.FormatVersion; set => Def.FormatVersion = value; }

        /// <summary>
        /// The data version of the def.
        /// </summary>
        public short DataVersion { get => Def.DataVersion; set => Def.DataVersion = value; }

        /// <summary>
        /// The game the param def originated from.
        /// </summary>
        public string Game { get; set; } = string.Empty;

        /// <summary>
        /// The param def itself.
        /// </summary>
        public PARAMDEF Def { get; set; } = new PARAMDEF();

        /// <summary>
        /// The fields in the param def.
        /// </summary>
        public List<PARAMDEF.Field> Fields => Def.Fields;

        /// <summary>
        /// The number of fields in the param def.
        /// </summary>
        public int FieldCount => Def.Fields.Count;

        /// <summary>
        /// Create a new, blank param def info.
        /// </summary>
        public ParamdefInfo(){}

        /// <summary>
        /// Read a paramdef from a path.
        /// </summary>
        /// <param name="path">The full file path to a param def.</param>
        public ParamdefInfo(string path)
        {
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
            Path = path;

            if (path.EndsWith(".xml"))
                Def = PARAMDEF.XmlDeserialize(path);
            else
                Def = PARAMDEF.Read(path);
        }

        /// <summary>
        /// Set a paramdef with no name or path given.
        /// </summary>
        /// <param name="def">A param def.</param>
        public ParamdefInfo(PARAMDEF def)
        {
            Def = def;
        }

        /// <summary>
        /// Set a paramdef with a path given and get name using the path.
        /// </summary>
        /// <param name="def">A param def.</param>
        public ParamdefInfo(string path, PARAMDEF def)
        {
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
            Path = path;
            Def = def;
        }

        /// <summary>
        /// Set a paramdef with name and path given.
        /// </summary>
        /// <param name="def">A param def.</param>
        public ParamdefInfo(string name, string path, PARAMDEF def)
        {
            Name = name;
            Path = path;
            Def = def;
        }

        /// <summary>
        /// Write the paramdef to the stored path.
        /// </summary>
        public void WriteToPath()
        {
            Def.Write(Path);
        }

        /// <summary>
        /// Write the paramdef to an array of bytes.
        /// </summary>
        /// <returns>An array of bytes.</returns>
        public byte[] WriteToBytes()
        {
            return Def.Write();
        }
    }
}
