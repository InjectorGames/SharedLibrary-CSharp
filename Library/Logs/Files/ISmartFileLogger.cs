using System.Net;

namespace InjectorGames.SharedLibrary.Logs.Files
{
    /// <summary>
    /// Smart file logger interface
    /// </summary>
    public interface ISmartFileLogger : IFileLogger
    {
        /// <summary>
        /// Fatal error SMTP server host
        /// </summary>
        string SmtpHost { get; }
        /// <summary>
        /// Fatal error SMTP server port
        /// </summary>
        int SmtpPort { get; }
        /// <summary>
        /// Fatal error SMTP from address
        /// </summary>
        string FromAddress { get; }
        /// <summary>
        /// Fatal error SMTP to address
        /// </summary>
        string ToAddress { get; }
        /// <summary>
        /// Fatal error SMTP enable SSL
        /// </summary>
        bool SmtpEnableSsl { get; }
        /// <summary>
        /// Fatal error SMTP credentials
        /// </summary>
        ICredentialsByHost SmtpCredentials { get; }
    }
}
