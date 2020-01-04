using InjectorGames.SharedLibrary.Times;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace InjectorGames.SharedLibrary.Logs.Files
{
    /// <summary>
    /// File logger class
    /// </summary>
    public class FileLogger : Logger, IFileLogger
    {
        /// <summary>
        /// Log file path
        /// </summary>
        protected readonly string logFilePath;
        /// <summary>
        /// Logger file stream
        /// </summary>
        protected readonly FileStream stream;

        /// <summary>
        /// Log file path
        /// </summary>
        public string LogFilePath => logFilePath;
        /// <summary>
        /// Write log messages to the console
        /// </summary>
        public bool WriteToConsole { get; set; }

        /// <summary>
        /// Creates a new file stream logger class instance
        /// </summary>
        public FileLogger(bool writeToConsole, string logFolderPath, IClock clock, LogType level = LogType.All) : base(clock, level)
        {
            WriteToConsole = writeToConsole;

            if (!Directory.Exists(logFolderPath))
                Directory.CreateDirectory(logFolderPath);

            logFilePath = logFolderPath + DateTime.Now.ToString("yyyy-M-dd_HH-mm-ss");
            stream = new FileStream(logFilePath, FileMode.CreateNew, FileAccess.Write);

            Info("Started file logger stream.");
        }

        /// <summary>
        /// Closes file logger
        /// </summary>
        public override void Close()
        {
            lock (stream)
            {
                Info("Closing file logger stream...");
                stream.Close();
            }
        }

        /// <summary>
        /// Logs a new message at fatal log level
        /// </summary>
        public override void Fatal(object message) { WriteToStream($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Fatal]: {message}\n"); }
        /// <summary>
        /// Logs a new message at error log level
        /// </summary>
        public override void Error(object message) { WriteToStream($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Error]: {message}\n"); }
        /// <summary>
        /// Logs a new message at warning log level
        /// </summary>
        public override void Warning(object message) { WriteToStream($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Warning]: {message}\n"); }
        /// <summary>
        /// Logs a new message at info log level
        /// </summary>
        public override void Info(object message) { WriteToStream($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Info]: {message}\n"); }
        /// <summary>
        /// Logs a new message at fatal log level
        /// </summary>
        public override void Debug(object message) { WriteToStream($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Debug]: {message}\n"); }
        /// <summary>
        /// Logs a new message at fatal log level
        /// </summary>
        public override void Trace(object message) { WriteToStream($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Trace]: {message}\n"); }

        /// <summary>
        /// Writes logger message to the file stream
        /// </summary>
        protected void WriteToStream(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);

            lock (stream)
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();

                if (WriteToConsole)
                    Console.Write(message);
            }
        }
    }
}
