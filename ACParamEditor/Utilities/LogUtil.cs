using System;
using System.IO;

namespace Utilities
{
    internal static class LogUtil
    {
        /// <summary>
        /// Create log files and overwrites them if they already exist.
        /// </summary>
        /// <param name="logPath">The save path for the log to be created.</param>
        /// <param name="stacktracePath">The save path for the stacktrace log to be created..</param>
        public static void CreateLog(string? logPath = null, string? stacktracePath = null) 
        {
            File.WriteAllText(logPath ?? PathUtil.Log, string.Empty);
            File.WriteAllText(stacktracePath ?? PathUtil.StackTraceLog, string.Empty);
        }

        /// <summary>
        /// Create a log file and overwrite it if it already exists.
        /// </summary>
        /// <param name="path">The save path for the log to be created.</param>
        public static void CreateLog(string path)
        {
            File.WriteAllText(path, string.Empty);
        }

        /// <summary>
        /// Create a stacktrace log file and overwrite it if it already exists.
        /// </summary>
        /// <param name="path">The save path for the stacktrace log to be created.</param>
        public static void CreateStackTraceLog(string path)
        {
            File.WriteAllText(path, string.Empty);
        }

        /// <summary>
        /// Append all provided log lines to the provided logs, creating them if they do not already exist.
        /// </summary>
        /// <param name="logLines">The lines to append to the log file.</param>
        /// <param name="stacktraceLines">The lines to append to the stacktrace log file.</param>
        /// <param name="logPath">The full path to the log.</param>
        /// <param name="stacktracePath">The full path to the stacktrace log.</param>
        public static void AppendLog(IEnumerable<string> logLines, IEnumerable<string> stacktraceLines, string? logPath = null, string? stacktracePath = null)
        {
            if (!File.Exists(logPath) || !File.Exists(stacktracePath))
                CreateLog();
            File.AppendAllLines(logPath ?? PathUtil.Log, logLines);
            File.AppendAllLines(stacktracePath ?? PathUtil.StackTraceLog, stacktraceLines);
        }

        /// <summary>
        /// Log something with an exception, date, and time.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="description">The description of what to log.</param>
        public static void LogExceptionWithDate(Exception ex, string? description = null) 
        {
            using (StreamWriter swLog = File.AppendText(PathUtil.Log))
            {
                swLog.WriteLine($"{description} on {DateTime.Now}");
            }

            using (StreamWriter swStacktrace = File.AppendText(PathUtil.StackTraceLog))
            {
                swStacktrace.WriteLine($"Description: \"{description ?? "Unknown Error"}\" on {DateTime.Now}\nException: {ex.Message}\nStacktrace: {ex}");
                swStacktrace.Close();
            }
        }

        /// <summary>
        /// Log something with an exception.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="description">The description of what to log.</param>
        public static void LogException(Exception ex, string? description = null)
        {
            using (StreamWriter swLog = File.AppendText(PathUtil.Log))
            {
                swLog.WriteLine($"{description}");
            }

            using (StreamWriter swStacktrace = File.AppendText(PathUtil.StackTraceLog))
            {
                swStacktrace.WriteLine($"Description: \"{description ?? "Unknown Error"}\" \nException: {ex.Message}\nStacktrace: {ex}");
            }
        }

        /// <summary>
        /// Log something with the date and time.
        /// </summary>
        /// <param name="description">The description of what to log</param>
        public static void LogWithDate(string? description = null) 
        {
            using (StreamWriter sw = File.AppendText(PathUtil.Log))
            {
                sw.WriteLine($"{description ?? "Log with date was called"} on {DateTime.Now}");
            }
        }

        /// <summary>
        /// Log something.
        /// </summary>
        /// <param name="description">The description of what to log.</param>
        public static void Log(string? description = null)
        {
            using (StreamWriter sw = File.AppendText(PathUtil.Log))
            {
                sw.WriteLine($"{description ?? "Log was called"}");
            }
        }
    }
}
