using InjectorGames.SharedLibrary.Times;
using System.Net;
using System.Net.Mail;

namespace InjectorGames.SharedLibrary.Logs.Files
{
    /// <summary>
    /// Smart file logger class
    /// </summary>
    public class SmartFileLogger : FileLogger, ISmartFileLogger
    {
        /// <summary>
        /// Fatal error SMTP server host
        /// </summary>
        protected readonly string smtpHost;
        /// <summary>
        /// Fatal error SMTP server port
        /// </summary>
        protected readonly int smtpPort;
        /// <summary>
        /// Fatal error SMTP from address
        /// </summary>
        protected readonly string fromAddress;
        /// <summary>
        /// Fatal error SMTP to address
        /// </summary>
        protected readonly string toAddress;
        /// <summary>
        /// Fatal error SMTP enable SSL
        /// </summary>
        protected readonly bool smtpEnableSsl;
        /// <summary>
        /// Fatal error SMTP credentials
        /// </summary>
        protected readonly ICredentialsByHost smtpCredentials;

        /// <summary>
        /// Fatal error SMTP server host
        /// </summary>
        public string SmtpHost => smtpHost;
        /// <summary>
        /// Fatal error SMTP server port
        /// </summary>
        public int SmtpPort => smtpPort;
        /// <summary>
        /// Fatal error SMTP from address
        /// </summary>
        public string FromAddress => fromAddress;
        /// <summary>
        /// Fatal error SMTP to address
        /// </summary>
        public string ToAddress => toAddress;
        /// <summary>
        /// Fatal error SMTP enable SSL
        /// </summary>
        public bool SmtpEnableSsl => smtpEnableSsl;
        /// <summary>
        /// Fatal error SMTP credentials
        /// </summary>
        public ICredentialsByHost SmtpCredentials => smtpCredentials;

        /// <summary>
        /// Creates a new smart file stream logger class instance
        /// </summary>
        public SmartFileLogger(string smtpHost, int smtpPort, string fromAddress, string toAddress, bool smtpEnableSsl, ICredentialsByHost smtpCredentials, bool writeToConsole, string logFolderPath, IClock timer, LogType level = LogType.All) : base(writeToConsole, logFolderPath, timer, level)
        {
            this.smtpHost = smtpHost;
            this.smtpPort = smtpPort;
            this.fromAddress = fromAddress;
            this.toAddress = toAddress;
            this.smtpEnableSsl = smtpEnableSsl;
            this.smtpCredentials = smtpCredentials;
        }

        /// <summary>
        /// Logs a new message at fatal log level
        /// </summary>
        public override void Fatal(object message)
        {
            base.Fatal(message);

            var smtpClient = new SmtpClient(smtpHost, smtpPort)
            {
                EnableSsl = smtpEnableSsl,
                Credentials = smtpCredentials,
            };

            var subject = "Logged Fatal Message";
            smtpClient.Send(fromAddress, toAddress, subject, message.ToString());
        }
    }
}
