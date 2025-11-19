using System.IO;

namespace AcParamEditor.Utilities
{
    internal static class PathEx
    {
        /// <summary>
        /// Removes all file extensions of a path.
        /// </summary>
        /// <param name="path">The path to remove the extensions of.</param>
        /// <returns>A path with file extensions removed.</returns>
        public static string RemoveFileExtensions(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return path;

            // Try to get the directory separator
            int separatorIndex = path.IndexOf('\\');
            if (separatorIndex < 0)
                separatorIndex = path.IndexOf('/');
            if (separatorIndex < 0)
                separatorIndex = path.IndexOf(Path.DirectorySeparatorChar);
            if (separatorIndex < 0)
                separatorIndex = path.IndexOf(Path.AltDirectorySeparatorChar);

            // If we found the directory separator, find the first dot after it, instead of a potential folder name with '.' in it.
            int dotIndex;
            if (separatorIndex > -1)
                dotIndex = path[separatorIndex..].IndexOf('.') + separatorIndex;
            else
                dotIndex = path.IndexOf('.');

            return dotIndex > -1 ? path[..dotIndex] : path;
        }
    }
}
