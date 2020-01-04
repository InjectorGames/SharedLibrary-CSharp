namespace InjectorGames.SharedLibrary.Logs.Files
{
    /// <summary>
    /// File logger interface
    /// </summary>
    public interface IFileLogger : ILogger
    {
        /// <summary>
        /// Log file path
        /// </summary>
        string LogFilePath { get; }
        /// <summary>
        /// Write log messages to the console
        /// </summary>
        bool WriteToConsole { get; set; }
    }
}
