using InjectorGames.SharedLibrary.Times;
using System;

namespace InjectorGames.SharedLibrary.Logs
{
    /// <summary>
    /// Abstract logger class
    /// </summary>
    public abstract class Logger : ILogger
    {
        /// <summary>
        /// Logger clock
        /// </summary>
        protected readonly IClock clock;

        /// <summary>
        /// Logger clock
        /// </summary>
        public IClock Clock => clock;

        /// <summary>
        /// Logger logging level
        /// </summary>
        public LogType Level { get; set; }

        /// <summary>
        /// Creates a new abstract logger class instance
        /// </summary>
        public Logger(IClock clock, LogType level = LogType.All)
        {
            this.clock = clock ?? throw new ArgumentNullException();
            Level = level;
        }

        /// <summary>
        /// Closes logger
        /// </summary>
        public virtual void Close() { Info("Logger closed."); }

        /// <summary>
        /// Returns true if logger should log this level
        /// </summary>
        public virtual bool Log(LogType level) { return level <= Level; }

        /// <summary>
        /// Logs a new message at fatal log level
        /// </summary>
        public abstract void Fatal(object message);
        /// <summary>
        /// Logs a new message at error log level
        /// </summary>
        public abstract void Error(object message);
        /// <summary>
        /// Logs a new message at warning log level
        /// </summary>
        public abstract void Warning(object message);
        /// <summary>
        /// Logs a new message at info log level
        /// </summary>
        public abstract void Info(object message);
        /// <summary>
        /// Logs a new message at fatal log level
        /// </summary>
        public abstract void Debug(object message);
        /// <summary>
        /// Logs a new message at fatal log level
        /// </summary>
        public abstract void Trace(object message);
    }
}
