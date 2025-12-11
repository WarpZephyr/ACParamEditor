using System.Windows.Forms;

namespace CustomWinForms
{
    public static class FileDialogs
    {
        /// <summary>
        /// Get a single file from a user.
        /// </summary>
        /// <param name="title">A string containing the title to display in the dialog box.</param>
        /// <param name="filter">What filetypes should be shown in the "Files of type" filter.</param>
        /// <returns>A string representing the path to a file a user selects.</returns>
        public static string? GetFilePath(string? title = null, string? filter = null)
        {
            OpenFileDialog filePathDialog = new OpenFileDialog()
            {
                Title = title ?? "Select a file to open.",
                Filter = filter ?? "All files (*.*)|*.*"
            };

            return filePathDialog.ShowDialog() == DialogResult.OK ? filePathDialog.FileName : null;
        }

        /// <summary>
        /// Get a save path from a user.
        /// </summary>
        /// <param name="title">A string containing the title to display in the dialog box.</param>
        /// <param name="filter">What filetypes should be shown in the "Files of type" filter.</param>
        /// <returns>A string representing the path to a file a user selects.</returns>
        public static string? GetSavePath(string? title = null, string? filter = null)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = title ?? "Select a file to open.",
                Filter = filter ?? "All files (*.*)|*.*"
            };

            return saveFileDialog.ShowDialog() == DialogResult.OK ? saveFileDialog.FileName : null;
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
        /// <param name="title">A string containing the title to display in the dialog box.</param>
        /// <param name="filter">What filetypes should be shown in the "Files of type" filter.</param>
        /// <returns>A string array representing the paths to files a user selects.</returns>
        public static string[] GetFilePaths(string? title = null, string? filter = null)
        {
            OpenFileDialog filePathDialog = new OpenFileDialog()
            {
                Title = title ?? "Select a file to open.",
                Filter = filter ?? "All files (*.*)|*.*",
                Multiselect = true
            };

            return filePathDialog.ShowDialog() == DialogResult.OK ? filePathDialog.FileNames : [];
        }
    }
}
