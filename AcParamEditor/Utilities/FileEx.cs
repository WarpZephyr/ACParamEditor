using System.IO;

namespace AcParamEditor.Utilities
{
    internal static class FileEx
    {
        /// <summary>
        /// Backup a file at the specified path.
        /// </summary>
        /// <param name="path">The path to the file to backup.</param>
        public static void BackupFile(string path)
        {
            if (File.Exists(path))
            {
                string bakPath = path + ".bak";
                if (!File.Exists(bakPath))
                {
                    File.Move(path, bakPath);
                }
            }
        }
    }
}
