using SoulsFormats;
using System.Security.Cryptography;

namespace ACParamEditor
{
    /// <summary>
    /// A class for storing information about loaded params.
    /// </summary>
    public class ParamInfo
    {
        /// <summary>
        /// The name of the file the param is from.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A full path to the file the param is from.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The ParamType of the param.
        /// </summary>
        public string Type
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to get param type from it.");

                return Param.ParamType;
            }
        }

        /// <summary>
        /// The game the param originated from.
        /// </summary>
        public string Game { get; set; } = string.Empty;

        /// <summary>
        /// The param itself.
        /// </summary>
        public PARAM? Param { get; set; }

        /// <summary>
        /// The def applied to the param.
        /// </summary>
        public PARAMDEF? Def
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to get def from it.");

                return Param.AppliedParamdef;
            }
        }

        /// <summary>
        /// The type of compression that was applied to the param file when read.
        /// </summary>
        public DCX.Type Compression
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to get compression type from it.");

                return Param.Compression;
            }
            set
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to set it's compression type.");

                Param.Compression = value;
            }
        }

        /// <summary>
        /// The current revision of the row structure within the param.
        /// </summary>
        public short Revision
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to get revision from it.");

                return Param.ParamdefDataVersion;
            }
        }

        /// <summary>
        /// Originally matched the paramdef for version 101, but since is always 0 or 0xFF.
        /// </summary>
        public short FormatVersion
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to get format version from it.");

                return Param.ParamdefFormatVersion;
            }
        }

        /// <summary>
        /// The number of rows in the param.
        /// </summary>
        public int RowCount
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to get row count from it.");
                return Param.Rows.Count;
            }
        }

        /// <summary>
        /// The total number of cells in the param.
        /// </summary>
        public int TotalCellCount
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to get total cell count from it.");

                if (!AppliedDef)
                    throw new InvalidOperationException("Def must be applied to param first to get the total cell count.");

                if (Param.Rows.Count == 0)
                    throw new InvalidOperationException("Param must have at least one row.");

                return CellsPerRow * RowCount;
            }
        }

        /// <summary>
        /// The number of cells per row in the param.
        /// </summary>
        public int CellsPerRow
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to get cell count per row from it.");

                if (Param.Rows.Count == 0)
                    throw new InvalidOperationException("Param must have at least one row.");

                return Param.Rows[0].Cells.Count;
            }
        }

        /// <summary>
        /// Get the detected size of the param.
        /// </summary>
        public long DetectedSize
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to get detected size from it.");

                return Param.DetectedSize;
            }
        }

        /// <summary>
        /// Whether or not a def has been applied to the param.
        /// </summary>
        public bool AppliedDef
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to check if it has a def applied.");

                return Param.AppliedParamdef != null;
            }
        }

        /// <summary>
        /// Whether or not the param is read and written in Big Endian.
        /// </summary>
        public bool BigEndian
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to check endianness.");

                return Param.BigEndian;
            }
        }

        /// <summary>
        /// Whether or not the param file was compressed when read.
        /// </summary>
        public bool Compressed
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to check if it is compressed.");

                return Param.Compression != DCX.Type.None;
            }
        }

        /// <summary>
        /// Set whether or not this param has been modified since last save.
        /// </summary>
        public bool Modified { get; set; } = false;

        public ParamInfo()
        {
            Path = string.Empty;
            Name = string.Empty;
            Param = null;
        }

        /// <summary>
        /// Read a param from a path and get its info.
        /// </summary>
        /// <param name="path">The path to a param to read.</param>
        public ParamInfo(string path)
        {
            Path = path;
            Name = System.IO.Path.GetFileName(Path);
            Param = PARAM.Read(Path);
        }

        /// <summary>
        /// Get the info for a param without providing the path or name.
        /// </summary>
        /// <param name="param">A param.</param>
        public ParamInfo(PARAM param)
        {
            Path = string.Empty;
            Name = string.Empty;
            Param = param;
        }

        /// <summary>
        /// Get the info for a param and set only its name.
        /// </summary>
        /// <param name="param">A param.</param>
        /// <param name="name">The name of the param.</param>
        public ParamInfo(PARAM param, string name)
        {
            Path = string.Empty;
            Name = name;
            Param = param;
        }

        /// <summary>
        /// Get the info for a param and set its path and name.
        /// </summary>
        /// <param name="param">A param.</param>
        /// <param name="path">The path to the param.</param>
        /// <param name="name">The name of the param.</param>
        public ParamInfo(PARAM param, string path, string name)
        {
            Path = path;
            Name = name;
            Param = param;
        }

        /// <summary>
        /// Read a param, set the path of the param, then apply a def read from a path.
        /// </summary>
        /// <param name="path">The path to a param to read.</param>
        /// <param name="defpath">The path to a def for the param to read.</param>
        public ParamInfo(string path, string defpath)
        {
            Path = path;
            Name = System.IO.Path.GetFileName(Path);
            Param = PARAM.Read(Path);
            Param.ApplyParamdefSomewhatCarefully(PARAMDEF.Read(defpath));
        }

        /// <summary>
        /// Read a param, set the path of the param, then apply a def.
        /// </summary>
        /// <param name="path">The path to a param to read.</param>
        /// <param name="def">A def to apply to the param.</param>
        public ParamInfo(string path, PARAMDEF def)
        {
            Path = path;
            Name = System.IO.Path.GetFileName(Path);
            Param = PARAM.Read(Path);
            Param.ApplyParamdefSomewhatCarefully(def);
        }

        /// <summary>
        /// Read a param, set the path of the param, then attempt to apply defs from a list to the param.
        /// </summary>
        /// <param name="path">The path to a param to read.</param>
        /// <param name="defs">A list of defs to apply to the param.</param>
        public ParamInfo(string path, IList<PARAMDEF> defs)
        {
            Path = path;
            Name = System.IO.Path.GetFileName(Path);
            Param = PARAM.Read(Path);
            Param.ApplyParamdefSomewhatCarefully(defs);
        }

        /// <summary>
        /// Get the info for a param and attempt to apply defs from a list to the param.
        /// </summary>
        /// <param name="param">A param.</param>
        /// <param name="defs">A list of defs to apply to the param.</param>
        public ParamInfo(PARAM param, IList<PARAMDEF> defs)
        {
            Path = string.Empty;
            Name = string.Empty;
            Param = param;
            Param.ApplyParamdefSomewhatCarefully(defs);
        }

        /// <summary>
        /// Get the info for a param, set the path, then attempt to apply defs from a list to the param.
        /// </summary>
        /// <param name="param">A param.</param>
        /// <param name="path">The path to the param.</param>
        /// <param name="defs">A list of defs to apply to the param.</param>
        public ParamInfo(PARAM param, string path, IList<PARAMDEF> defs)
        {
            Path = path;
            Name = System.IO.Path.GetFileName(Path);
            Param = param;
            Param.ApplyParamdefSomewhatCarefully(defs);
        }

        /// <summary>
        /// Get the info for a param, set the path and name, then attempt to apply defs from a list to the param.
        /// </summary>
        /// <param name="param">A param.</param>
        /// <param name="name">The name of the param.</param>
        /// <param name="path">The path to the param.</param>
        /// <param name="defs">A list of defs to apply to the param.</param>
        public ParamInfo(PARAM param, string path, string name, IList<PARAMDEF> defs)
        {
            Path = path;
            Name = name;
            Param = param;
            Param.ApplyParamdefSomewhatCarefully(defs);
        }

        public string GetNameFromPath()
        {
            if (!File.Exists(Path))
                throw new InvalidOperationException("The name cannot be retrieved from the path as a file was not found.");
            return System.IO.Path.GetFileName(Path);
        }

        /// <summary>
        /// Set the name of the param from its path.
        /// </summary>
        /// <exception cref="InvalidOperationException">A file could not be found on the set path.</exception>
        public void SetNameFromPath()
        {
            if (!File.Exists(Path))
                throw new InvalidOperationException("The name cannot be retrieved from the path as a file was not found.");

            Name = System.IO.Path.GetFileName(Path);
        }

        /// <summary>
        /// Get the smallest row ID in the param.
        /// </summary>
        /// <returns>The smallest row ID in the param.</returns>
        /// <exception cref="InvalidOperationException">The param was null or had no rows.</exception>
        public int GetMinRowID()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get row ids from it.");
            if (RowCount == 0)
                throw new InvalidOperationException("Param must have at least one row.");

            int min = 0;
            foreach (var row in Param.Rows)
                if (row.ID < min)
                    min = row.ID;
            return min;
        }

        /// <summary>
        /// Get the largest row ID in the param.
        /// </summary>
        /// <returns>The largest row ID in the param.</returns>
        /// <exception cref="InvalidOperationException">The param was null or had no rows.</exception>
        public int GetMaxRowID()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get row ids from it.");
            if (RowCount == 0)
                throw new InvalidOperationException("Param must have at least one row.");

            int max = 0;
            foreach (var row in Param.Rows)
                if (row.ID > max)
                    max = row.ID;
            return max;
        }

        /// <summary>
        /// Get a row ID one integer above the max row ID in the param.
        /// </summary>
        /// <returns>A row ID one integer above the max row ID in the param.</returns>
        public int GetNextRowID()
        {
            return GetMaxRowID() + 1;
        }

        /// <summary>
        /// Get the ids of all the rows in a param.
        /// </summary>
        /// <returns>An int array with all the row ids in this param.</returns>
        /// <exception cref="InvalidOperationException">The param was null.</exception>
        public int[] GetRowIDs()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get row ids from it.");
            int[] ids = new int[RowCount];
            for (int i = 0; i < RowCount; i++)
                ids[i] = Param.Rows[i].ID;
            return ids;
        }

        /// <summary>
        /// Set the ids of all the rows in a param.
        /// </summary>
        /// <param name="ids">A list of ids to set.</param>
        /// <exception cref="InvalidOperationException">The param was null or the number of ids to set did not match the number of rows.</exception>
        public void SetRowIDs(IList<int> ids)
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to set it's row ids.");
            if (ids.Count != RowCount)
                throw new InvalidOperationException("The number of ids to set did not match the number of rows.");

            for (int i = 0; i < RowCount; i++)
                Param.Rows[i].ID = ids[i];
            Modified = true;
        }

        /// <summary>
        /// Get the names of all the rows in a param.
        /// </summary>
        /// <returns>A string array with all the row names in this param.</returns>
        /// <exception cref="InvalidOperationException">The param was null.</exception>
        public string[] GetRowNames()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get row names from it.");
            string[] names = new string[RowCount];
            for (int i = 0; i < RowCount; i++)
                names[i] = Param.Rows[i].Name;
            return names;
        }

        /// <summary>
        /// Set the names of all the rows in a param.
        /// </summary>
        /// <param name="names">A list of names to set.</param>
        /// <exception cref="InvalidOperationException">The param was null or the number of names to set did not match the number of rows.</exception>
        public void SetRowNames(IList<string> names)
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to set it's row names.");
            if (names.Count != RowCount)
                throw new InvalidOperationException("The number of names to set did not match the number of rows.");

            for (int i = 0; i < RowCount; i++)
                Param.Rows[i].Name = names[i];
            Modified = true;
        }

        /// <summary>
        /// Get the display names of all the cells in each row of the param.
        /// </summary>
        /// <returns>A string array with the display names of all the cells in each row of this param.</returns>
        /// <exception cref="InvalidOperationException">The param or paramdef was null, or the param had no rows.</exception>
        public string[] GetCellDisplayNames()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get cell display names from it.");
            if (!AppliedDef)
                throw new InvalidOperationException("Param must have def applied first to get cell display names from it.");
            if (Param.Rows.Count == 0)
                throw new InvalidOperationException("Param must have at least one row.");
            string[] names = new string[CellsPerRow];
            for (int i = 0; i < CellsPerRow; i++)
                names[i] = Param.Rows[0].Cells[i].Def.DisplayName;
            return names;
        }

        /// <summary>
        /// Get the internal names of all the cells in each row of the param.
        /// </summary>
        /// <returns>A string array with the internal names of all the cells in each row of this param.</returns>
        /// <exception cref="InvalidOperationException">The param or paramdef was null, or the param had no rows.</exception>
        public string[] GetCellInternalNames()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get cell internal names from it.");
            if (!AppliedDef)
                throw new InvalidOperationException("Param must have def applied first to get cell internal names from it.");
            if (Param.Rows.Count == 0)
                throw new InvalidOperationException("Param must have at least one row.");
            string[] names = new string[CellsPerRow];
            for (int i = 0; i < CellsPerRow; i++)
                names[i] = Param.Rows[0].Cells[i].Def.InternalName;
            return names;
        }

        /// <summary>
        /// Get the descriptions of all the cells in each row of the param.
        /// </summary>
        /// <returns>A string array with the descriptions of all the cells in each row of this param.</returns>
        /// <exception cref="InvalidOperationException">The param or paramdef was null, or the param had no rows.</exception>
        public string[] GetCellDescriptions()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get cell descriptions from it.");
            if (!AppliedDef)
                throw new InvalidOperationException("Param must have def applied first to get cell descriptions from it.");
            if (Param.Rows.Count == 0)
                throw new InvalidOperationException("Param must have at least one row.");
            string[] names = new string[CellsPerRow];
            for (int i = 0; i < CellsPerRow; i++)
                names[i] = Param.Rows[0].Cells[i].Def.Description;
            return names;
        }

        /// <summary>
        /// Get the display formats of all the cells in each row of the param.
        /// </summary>
        /// <returns>A string array with the display formats of all the cells in each row of this param.</returns>
        /// <exception cref="InvalidOperationException">The param or paramdef was null, or the param had no rows.</exception>
        public string[] GetCellDisplayFormats()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get cell display formats from it.");
            if (!AppliedDef)
                throw new InvalidOperationException("Param must have def applied first to get cell display formats from it.");
            if (Param.Rows.Count == 0)
                throw new InvalidOperationException("Param must have at least one row.");
            string[] names = new string[CellsPerRow];
            for (int i = 0; i < CellsPerRow; i++)
                names[i] = Param.Rows[0].Cells[i].Def.DisplayFormat;
            return names;
        }

        /// <summary>
        /// Get the defaults of all the cells in each row of the param.
        /// </summary>
        /// <returns>An object array with the defaults of all the cells in each row of this param.</returns>
        /// <exception cref="InvalidOperationException">The param or paramdef was null, or the param had no rows.</exception>
        public object[] GetCellDefaults()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get cell defaults from it.");
            if (!AppliedDef)
                throw new InvalidOperationException("Param must have def applied first to get cell defaults from it.");
            if (Param.Rows.Count == 0)
                throw new InvalidOperationException("Param must have at least one row.");
            object[] values = new object[CellsPerRow];
            for (int i = 0; i < CellsPerRow; i++)
                values[i] = Param.Rows[0].Cells[i].Def.Default;
            return values;
        }

        /// <summary>
        /// Get the increments of all the cells in each row of the param.
        /// </summary>
        /// <returns>An object array with the increments of all the cells in each row of this param.</returns>
        /// <exception cref="InvalidOperationException">The param or paramdef was null, or the param had no rows.</exception>
        public object[] GetCellIncrements()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get cell increments from it.");
            if (!AppliedDef)
                throw new InvalidOperationException("Param must have def applied first to get cell increments from it.");
            if (Param.Rows.Count == 0)
                throw new InvalidOperationException("Param must have at least one row.");
            object[] values = new object[CellsPerRow];
            for (int i = 0; i < CellsPerRow; i++)
                values[i] = Param.Rows[0].Cells[i].Def.Increment;
            return values;
        }

        /// <summary>
        /// Get the minimums of all the cells in each row of the param.
        /// </summary>
        /// <returns>An object array with the minimums of all the cells in each row of this param.</returns>
        /// <exception cref="InvalidOperationException">The param or paramdef was null, or the param had no rows.</exception>
        public object[] GetCellMinimums()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get cell minimums from it.");
            if (!AppliedDef)
                throw new InvalidOperationException("Param must have def applied first to get cell minimums from it.");
            if (Param.Rows.Count == 0)
                throw new InvalidOperationException("Param must have at least one row.");
            object[] values = new object[CellsPerRow];
            for (int i = 0; i < CellsPerRow; i++)
                values[i] = Param.Rows[0].Cells[i].Def.Minimum;
            return values;
        }

        /// <summary>
        /// Get the maximums of all the cells in each row of the param.
        /// </summary>
        /// <returns>An object array with the maximums of all the cells in each row of this param.</returns>
        /// <exception cref="InvalidOperationException">The param or paramdef was null, or the param had no rows.</exception>
        public object[] GetCellMaximums()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get cell maximums from it.");
            if (!AppliedDef)
                throw new InvalidOperationException("Param must have def applied first to get cell maximums from it.");
            if (Param.Rows.Count == 0)
                throw new InvalidOperationException("Param must have at least one row.");
            object[] values = new object[CellsPerRow];
            for (int i = 0; i < CellsPerRow; i++)
                values[i] = Param.Rows[0].Cells[i].Def.Maximum;
            return values;
        }

        /// <summary>
        /// Get the display types of all the cells in each row of the param.
        /// </summary>
        /// <returns>A DefType array with the display types of all the cells in each row of this param.</returns>
        /// <exception cref="InvalidOperationException">The param or paramdef was null, or the param had no rows.</exception>
        public DefType[] GetCellTypes()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to get cell types from it.");
            if (!AppliedDef)
                throw new InvalidOperationException("Param must have def applied first to get cell types from it.");
            if (Param.Rows.Count == 0)
                throw new InvalidOperationException("Param must have at least one row.");
            DefType[] types = new DefType[CellsPerRow];
            for (int i = 0; i < CellsPerRow; i++)
                types[i] = Param.Rows[0].Cells[i].Def.DisplayType;
            return types;
        }

        /// <summary>
        /// Get a SHA256 hash of the param as a byte array.
        /// </summary>
        /// <returns>A SHA256 hash byte array.</returns>
        public byte[] GetHash()
        {
            SHA256 sha = SHA256.Create();
            byte[] param = WriteToBytes();
            return sha.ComputeHash(param);
        }

        /// <summary>
        /// Check if a row is compatible with the param.
        /// </summary>
        /// <param name="row">The row to check for compatibility.</param>
        /// <returns>Whether or not the row is compatible with the param.</returns>
        /// <exception cref="InvalidOperationException">The param was null.</exception>
        public bool RowCompatible(PARAM.Row row)
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to compare rows to its rows.");

            var rowsample = Param.Rows[0];
            if (rowsample.Cells.Count != row.Cells.Count)
                return false;

            for (int i = 0; i < rowsample.Cells.Count; i++)
                if (rowsample.Cells[i].Def != row.Cells[i].Def)
                    return false;

            return true;
        }

        /// <summary>
        /// Check if a row ID exists in the param.
        /// </summary>
        /// <param name="id">The id to check for.</param>
        /// <returns>Whether or not the row id exists in the param.</returns>
        /// <exception cref="InvalidOperationException">The param was null.</exception>
        public bool ContainsRowID(int id)
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to check its row IDs.");
            foreach (var row in Param.Rows)
                if (row.ID == id)
                    return true;
            return false;
        }

        /// <summary>
        /// Write the param to its set path.
        /// </summary>
        public void WriteToPath()
        {
            if (Path == null || Path == string.Empty)
                throw new InvalidOperationException("Path does not seem to be set.");
            if (Param == null)
                throw new InvalidOperationException("Param must exist to write it.");

            Param.Write(Path);
            Modified = false;
        }

        /// <summary>
        /// Write the param to a byte array and return it.
        /// </summary>
        /// <returns>A byte array.</returns>
        public byte[] WriteToBytes()
        {
            if (Param == null)
                throw new InvalidOperationException("Param must exist to write it.");
            return Param.Write();
        }

        /// <summary>
        /// Get the name of the param file.
        /// </summary>
        /// <returns>The name of the param file.</returns>
        public override string ToString() => Name;
    }
}
