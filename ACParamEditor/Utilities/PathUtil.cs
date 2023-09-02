using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace Utilities
{
    internal static class PathUtil
    {
        #region Helpful Static Properties

        /// <summary>
        /// A string representing the path to the folder the program is running from.
        /// </summary>
        public static string? EnvFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// A string representing the path to a generic resource folder named "res" inside of the directory the program is running from.
        /// </summary>
        public static string ResFolderPath = $"{EnvFolderPath}\\res";

        /// <summary>
        /// A string representing the path to a generic resource folder named "Resource" inside of the directory the program is running from.
        /// </summary>
        public static string ResourceFolderPath = $"{EnvFolderPath}\\Resource";

        /// <summary>
        /// A string representing the path to a generic resource folder named "Resources" inside of the directory the program is running from.
        /// </summary>
        public static string ResourcesFolderPath = $"{EnvFolderPath}\\Resources";

        /// <summary>
        /// A string representing the path to a generic stacktrace log file named "stacktrace.log" inside of the directory the program is running from.
        /// </summary>
        public static string StackTraceLog = $"{EnvFolderPath}\\stacktrace.log";

        /// <summary>
        /// A string representing the path to a generic log file named "log.log" inside of the directory the program is running from.
        /// </summary>
        public static string Log = $"{EnvFolderPath}\\log.log";

        /// <summary>
        /// A string representing the path to a generic log file named "log.txt" inside of the directory the program is running from.
        /// </summary>
        public static string LogTxt = $"{EnvFolderPath}\\log.txt";

        #endregion

        #region Get

        /// <summary>
        /// Get a single file from a user.
        /// </summary>
        /// <param name="initialDirectory">A string representing the path the dialog box should open in.</param>
        /// <param name="title">A string containing the title to display in the dialog box.</param>
        /// <param name="filter">What filetypes should be shown in the "Files of type" filter.</param>
        /// <returns>A string representing the path to a file a user selects.</returns>
        public static string? GetFilePath(string? initialDirectory = null, string? title = null, string? filter = null)
        {
            OpenFileDialog filePathDialog = new OpenFileDialog()
            {
                InitialDirectory = initialDirectory ?? "C:\\Users",
                Title = title ?? "Select a file to open.",
                Filter = filter ?? "All files (*.*)|*.*"
            };

            return filePathDialog.ShowDialog() == DialogResult.OK ? filePathDialog.FileName : null;
        }

        /// <summary>
        /// Get a save path from a user.
        /// </summary>
        /// <param name="initialDirectory">A string representing the path the dialog box should open in.</param>
        /// <param name="title">A string containing the title to display in the dialog box.</param>
        /// <param name="filter">What filetypes should be shown in the "Save as file type" filter.</param>
        /// <returns>A string representing the save path a user selects.</returns>
        public static string? GetSavePath(string? initialDirectory = null, string? title = null, string? filter = null)
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                InitialDirectory = initialDirectory ?? "C:\\Users",
                Title = title ?? "Select a location to save to.",
                Filter = filter ?? "All files (*.*)|*.*"
            };

            return saveDialog.ShowDialog() == DialogResult.OK ? saveDialog.FileName : null;
        }

        /// <summary>
        /// Get a single folder from a user.
        /// </summary>
        /// <returns>A string representing the path to a folder a user selects.</returns>
        public static string? GetFolderPath()
        {
            FolderBrowserDialog folderPathDialog = new FolderBrowserDialog();
            return folderPathDialog.ShowDialog() == DialogResult.OK ? folderPathDialog.SelectedPath : null;
        }

        /// <summary>
        /// Get multiple files from a user.
        /// </summary>
        /// <param name="initialDirectory">A string representing the path the dialog box should open in.</param>
        /// <param name="title">A string containing the title to display in the dialog box.</param>
        /// <param name="filter">What filetypes should be shown in the "Files of type" filter.</param>
        /// <returns>A string array representing the paths to files a user selects.</returns>
        public static string[] GetFilePaths(string? initialDirectory = null, string? title = null, string? filter = null)
        {
            OpenFileDialog filePathDialog = new OpenFileDialog()
            {
                InitialDirectory = initialDirectory ?? "C:\\Users",
                Title = title ?? "Select a file to open.",
                Filter = filter ?? "All files (*.*)|*.*",
                Multiselect = true
            };

            return filePathDialog.ShowDialog() == DialogResult.OK ? filePathDialog.FileNames.ToArray() : Array.Empty<string>();
        }

        /// <summary>
        /// Returns an entirely extensionless file name by removing all extensions.
        /// </summary>
        /// <param name="path">The path to remove the extensions of.</param>
        /// <returns>An entirely extensionless file name.</returns>
        /// <remarks>
        /// If the provided string was null, empty, or already extensionless it will just be returned as it is.
        /// </remarks>
        public static string GetExtensionlessFileName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }

            while (path.Contains('.'))
            {
                path = Path.GetFileNameWithoutExtension(path);
            }

            return path;
        }

        #endregion

        #region Operations

        /// <summary>
        /// Backup a file or folder on a path if it exists by adding .bak to its extension.
        /// </summary>
        /// <param name="path">A string representing the path to a file to backup.</param>
        public static void Backup(string path)
        {
            if (File.Exists(path) && !File.Exists($"{path}.bak"))
                File.Move(path, $"{path}.bak");

            else if (Directory.Exists(path) && !Directory.Exists($"{path}-bak"))
                Directory.Move(path, $"{path}-bak");
        }

        /// <summary>
        /// Restore a backup from a backup file or folder on a path if it exists by overwriting the current version of the file or folder with the backup.
        /// </summary>
        /// <param name="path">A string representing the path to a backup file to restore.</param>
        public static void Restore(string path)
        {
            if (File.Exists(path))
                File.Move(path, Path.GetFileNameWithoutExtension(path));

            else if (Directory.Exists(path))
                Directory.Move(path, path.Remove(path.Length - 4));
        }

        /// <summary>
        /// Delete a file on the specified path if it exists.
        /// </summary>
        /// <param name="path"></param>
        public static void Delete(string path)
        {
            if (File.Exists(path)) File.Delete(path);
        }

        /// <summary>
        /// Copies a file if it exists and the new file does not yet exist to the specified path as a new file.
        /// </summary>
        /// <param name="path">A string representing the path to a file to copy.</param>
        /// <param name="newPath">A string representing the path to copy the selected file to.</param>
        public static void CopyFile(string path, string newPath, bool overwrite)
        {
            if (File.Exists(path) && !File.Exists(newPath))
            {
                File.Copy(path, newPath);
            }
            else if (File.Exists(path) && File.Exists(newPath) && overwrite)
            {
                File.Delete(newPath);
                File.Copy(path, newPath);
            }
        }

        /// <summary>
        /// Copy a directory and all of its files and subdirectories.
        /// </summary>
        /// <param name="path">A string representing a path to the folder to copy.</param>
        /// <param name="newPath">A string representing a path to copy the selected folder to.</param>
        public static void CopyDirectory(string path, string newPath)
        {
            foreach (var directory in Directory.GetDirectories(path))
            {
                //Get the path of the new directory
                var newDirectory = Path.Combine(newPath, Path.GetFileName(directory));
                //Create the directory if it doesn't already exist
                Directory.CreateDirectory(newDirectory);
                //Recursively copy the directory
                CopyDirectory(directory, newDirectory);
            }

            foreach (var file in Directory.GetFiles(path))
            {
                File.Copy(file, Path.Combine(newPath, Path.GetFileName(file)));
            }
        }

        /// <summary>
        /// Clones a file on a path if it exists and deletes or backups the original.
        /// </summary>
        /// <param name="path">A string representing the path to a file to clone.</param>
        /// <param name="backup">Whether or not to retain the original with .bak added to its extension.</param>
        public static void Clone(string path, bool backup)
        {
            byte[] fileBytes = File.ReadAllBytes(path);

            if (backup)
                Backup(path);

            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllBytes(path, fileBytes);
        }

        /// <summary>
        /// Clones files on paths if they exist and deletes or backups the originals.
        /// </summary>
        /// <param name="paths">A string array representing the paths to files to clone.</param>
        /// <param name="backup">Whether or not to retain the original with .bak added to its extension.</param>
        public static void Clone(string[] paths, bool backup)
        {
            foreach (string path in paths)
            {
                Clone(path, backup);
            }
        }

        #endregion

        #region Write

        /// <summary>
        /// Writes a file overwriting if it exists and if specified to do so.
        /// </summary>
        /// <param name="path">A string representing a path to where the file is to be written or overwritten.</param>
        /// <param name="bytes">Bytes to write to the chosen file path.</param>
        /// <param name="overwrite">Whether or not to overwrite file if it already exists.</param>
        public static void Write(string path, byte[] bytes, bool overwrite = false)
        {
            if (!File.Exists(path))
                File.WriteAllBytes(path, bytes);

            else if (overwrite)
                File.WriteAllBytes(path, bytes);
        }

        #endregion

        #region Open

        /// <summary>
        /// Open a folder on the specified path in explorer.exe.
        /// </summary>
        /// <param name="folderPath">The path to the folder to open.</param>
        /// <returns>Whether or not opening the folder was successful.</returns>
        public static bool OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Open the "res" folder in the current program.
        /// </summary>
        /// <returns>Whether or not opening the folder was successful.</returns>
        public static bool OpenRes()
        {
            return OpenFolder(ResFolderPath);
        }

        /// <summary>
        /// Open the "Resource" folder in the current program.
        /// </summary>
        /// <returns>Whether or not opening the folder was successful.</returns>
        public static bool OpenResource()
        {
            return OpenFolder(ResourceFolderPath);
        }

        /// <summary>
        /// Open the "Resources" folder in the current program.
        /// </summary>
        /// <returns>Whether or not opening the folder was successful.</returns>
        public static bool OpenResources()
        {
            return OpenFolder(ResourcesFolderPath);
        }

        #endregion
    }
}
