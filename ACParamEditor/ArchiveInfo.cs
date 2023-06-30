using SoulsFormats;

namespace ACParamEditor
{
    public class ArchiveInfo
    {
        /// <summary>
        /// The name of the archive.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The full path to the archive.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// What type the archive is.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The archive itself.
        /// </summary>
        public object? Archive { get; set; }

        /// <summary>
        /// Create a new, blank archive.
        /// </summary>
        public ArchiveInfo()
        {
            Name = string.Empty;
            Path = string.Empty;
            Type = string.Empty;
            Archive = null;
        }

        public ArchiveInfo(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("A file could not be found on the provided path.");

            if (IsArchive(path))
            {
                Name = System.IO.Path.GetFileName(path);
                Path = path;
                Type = GetArchiveType(path);
                Archive = ReadArchive(path);
            }
            else
            {
                throw new NotSupportedException("The format could not be identified.");
            }

            Path = path;
            Name = System.IO.Path.GetFileName(path);
        }

        public ArchiveInfo(BND3 bnd, string path)
        {
            Archive = bnd;
            Name = System.IO.Path.GetFileName(path);
            Path = path;
            Type = "BND3";
        }

        public ArchiveInfo(BND4 bnd, string path)
        {
            Archive = bnd;
            Name = System.IO.Path.GetFileName(path);
            Path = path;
            Type = "BND4";
        }

        public static bool IsArchive(string path)
        {
            return IsArchive(File.ReadAllBytes(path));
        }

        public static bool IsArchive(byte[] bytes)
        {
            if (BND3.Is(bytes))
                return true;
            if (BND4.Is(bytes))
                return true;
            return false;
        }

        public static object? ReadArchive(string path)
        {
            return ReadArchive(File.ReadAllBytes(path));
        }

        public static object? ReadArchive(byte[] bytes)
        {
            if (BND3.Is(bytes))
                return BND3.Read(bytes);
            else if (BND4.Is(bytes))
                return BND4.Read(bytes);
            else
                return null;
        }

        public static string GetArchiveType(string path)
        {
            return GetArchiveType(File.ReadAllBytes(path));
        }

        public static string GetArchiveType(byte[] bytes)
        {
            if (BND3.Is(bytes))
                return "BND3";
            else if (BND4.Is(bytes))
                return "BND4";
            else
                return string.Empty;
        }

        public void WriteToPath()
        {
            if (Archive == null)
                throw new InvalidOperationException("Archive was found null.");

            if (Type == "BND3")
            {
                ((BND3)Archive).Write(Path);
            }
            else if (Type == "BND4")
            {
                ((BND4)Archive).Write(Path);
            }
        }

        public byte[] WriteToBytes()
        {
            if (Archive == null)
                throw new InvalidOperationException("Archive was found null.");

            if (Type == "BND3")
            {
                return ((BND3)Archive).Write();
            }
            else if (Type == "BND4")
            {
                return ((BND4)Archive).Write();
            }
            else
            {
                throw new NotSupportedException($"{Type} is not recognized as a supported type.");
            }
        }
    }
}
