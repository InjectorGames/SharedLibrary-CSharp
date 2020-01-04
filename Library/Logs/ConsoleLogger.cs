using InjectorGames.SharedLibrary.Times;
using System;
using System.Threading;

namespace InjectorGames.SharedLibrary.Logs
{
    /// <summary>
    /// Console logger class
    /// </summary>
    public class ConsoleLogger : Logger
    {
        /// <summary>
        /// Creates a new file stream logger class instance
        /// </summary>
        public ConsoleLogger(IClock clock, LogType level = LogType.All) : base(clock, level)
        {
            Info("Started console logger.");
        }

        /// <summary>
        /// Closes console logger
        /// </summary>
        public override void Close() { Info("Closed console logger."); }

        /// <summary>
        /// Logs a new message at fatal log level
        /// </summary>
        public override void Fatal(object message) { Console.WriteLine($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Fatal]: {message}"); }
        /// <summary>
        /// Logs a new message at error log level
        /// </summary>
        public override void Error(object message) { Console.WriteLine($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Error]: {message}"); }
        /// <summary>
        /// Logs a new message at warning log level
        /// </summary>
        public override void Warning(object message) { Console.WriteLine($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Warning]: {message}"); }
        /// <summary>
        /// Logs a new message at info log level
        /// </summary>
        public override void Info(object message) { Console.WriteLine($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Info]: {message}"); }
        /// <summary>
        /// Logs a new message at fatal log level
        /// </summary>
        public override void Debug(object message) { Console.WriteLine($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Debug]: {message}"); }
        /// <summary>
        /// Logs a new message at fatal log level
        /// </summary>
        public override void Trace(object message) { Console.WriteLine($"[{clock.MS}] [{Thread.CurrentThread.ManagedThreadId}] [Trace]: {message}"); }
    }
}
