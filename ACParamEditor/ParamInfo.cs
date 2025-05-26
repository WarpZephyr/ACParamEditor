using SoulsFormats;
using System.Security.Cryptography;

namespace ACParamEditor
{
    /// <summary>
    /// A class for storing information about loaded params.
    /// </summary>
    public class ParamInfo
    {
        #region Properties

        /// <summary>
        /// The name of the file the param is from.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A full path to the file the param is from.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The game the param originated from.
        /// </summary>
        public string Game { get; set; } = string.Empty;

        /// <summary>
        /// The ParamType of the param.
        /// </summary>
        public string Type => Param.ParamType;

        /// <summary>
        /// The param itself.
        /// </summary>
        public PARAM Param { get; set; }

        /// <summary>
        /// The def applied to the param.
        /// </summary>
        public PARAMDEF? Def => Param.AppliedParamdef;

        /// <summary>
        /// The type of compression that was applied to the param file when read.
        /// </summary>
        public DCX.Type Compression { get => Param.Compression; set => Param.Compression = value; }

        /// <summary>
        /// Originally matched the paramdef for version 101, but since is always 0 or 0xFF.
        /// </summary>
        public byte ParamFormatVersion { get => Param.ParamdefFormatVersion; set => Param.ParamdefFormatVersion = value; }

        /// <summary>
        /// Originally matched the paramdef for version 101, but since is always 0 or 0xFF.
        /// </summary>
        public short DefFormatVersion
        {
            get
            {
                if (Def == null)
                    throw new InvalidOperationException("Def must exist to get format version from it.");

                return Def.FormatVersion;
            }
        }

        /// <summary>
        /// The current revision of the row structure within the param.
        /// </summary>
        public short ParamDataVersion { get => Param.ParamdefDataVersion; set => Param.ParamdefDataVersion = value; }

        /// <summary>
        /// The current revision of the row structure within the param.
        /// </summary>
        public short DefDataVersion
        {
            get
            {
                if (Def == null)
                    throw new InvalidOperationException("Def must exist to get data version from it.");

                return Def.DataVersion;
            }
        }

        /// <summary>
        /// The number of rows in the param.
        /// </summary>
        public int RowCount => Param.Rows.Count;

        /// <summary>
        /// The total number of cells in the param.
        /// </summary>
        public int TotalCellCount => CellsPerRow * RowCount;

        /// <summary>
        /// The number of cells per row in the param.
        /// </summary>
        public int CellsPerRow
        {
            get
            {
                if (Def == null || !AppliedDef)
                    throw new InvalidOperationException("Def must be applied to param first to get a cell count.");

                return Def.Fields.Count;
            }
        }

        /// <summary>
        /// Get the detected size of rows in the param.
        /// </summary>
        public long DetectedRowSize
        {
            get
            {
                if (Param == null)
                    throw new InvalidOperationException("Param must exist to get detected size of rows from it.");

                return Param.DetectedSize;
            }
        }

        /// <summary>
        /// Whether or not a def has been applied to the param.
        /// </summary>
        public bool AppliedDef => Param.AppliedParamdef != null;

        /// <summary>
        /// Whether or not the param is read and written in Big Endian.
        /// </summary>
        public bool BigEndian { get => Param.BigEndian; set => Param.BigEndian = value; }

        /// <summary>
        /// Whether or not the param is to be compressed.
        /// </summary>
        public bool Compressed => Param.Compression != DCX.Type.None;

        /// <summary>
        /// Whether or not this param has a ParamType set.
        /// </summary>
        public bool HasType => !string.IsNullOrEmpty(Type);

        /// <summary>
        /// Set whether or not this param has been modified since last save.
        /// </summary>
        public bool Modified { get; set; } = false;

        #endregion

        #region Constructors

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
        /// Set a param, its def, and path.
        /// </summary>
        /// <param name="param">The param to get the info of.</param>
        /// <param name="def">A def to apply to the param.</param>
        /// <param name="path">The path to a param to read.</param>
        public ParamInfo(PARAM param, PARAMDEF? def, string path)
        {
            Path = path;
            Name = System.IO.Path.GetFileName(Path);
            Param = param;
            if (def != null)
            {
                Param.ApplyParamdefSomewhatCarefully(def);
            }
        }

        #endregion

        #region Get

        public string GetNameFromPath()
        {
            if (!File.Exists(Path))
                throw new InvalidOperationException("The name cannot be retrieved from the path as a file was not found.");
            return System.IO.Path.GetFileName(Path);
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

        #endregion

        #region Set

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

        #endregion

        #region Check

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

        #endregion

        #region Write

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

        #endregion

        /// <summary>
        /// Get the name of the param file.
        /// </summary>
        /// <returns>The name of the param file.</returns>
        public override string ToString()
            => Name;
    }
}
