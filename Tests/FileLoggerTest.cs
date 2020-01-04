using InjectorGames.SharedLibrary.Logs;
using InjectorGames.SharedLibrary.Logs.Files;
using InjectorGames.SharedLibrary.Times;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace InjectorGames.SharedLibrary.Tests
{
    [TestClass]
    public class FileLoggerTest
    {
        public const string path = "unit-tests-logs/";

        [TestMethod]
        public void Logging()
        {
            var clock = new Clock();
            clock.Start();

            var logger = new FileLogger(true, path, clock, LogType.All) as ILogger;

            if (logger.Log(LogType.Trace))
                logger.Trace("Test Trace.");
            if (logger.Log(LogType.Debug))
                logger.Debug("Test Debug.");
            if (logger.Log(LogType.Info))
                logger.Info("Test Info.");
            if (logger.Log(LogType.Warning))
                logger.Warning("Test Warning.");
            if (logger.Log(LogType.Error))
                logger.Error("Test Error.");
            if (logger.Log(LogType.Fatal))
                logger.Error("Test Fatal.");

            logger.Level = LogType.Info;
            if (logger.Log(LogType.Info))
                logger.Info("Test Info Equality.");

            logger.Level = LogType.Off;
            if (logger.Log(LogType.Error))
                logger.Error("Test Off.");

            logger.Close();

            var files = Directory.GetFiles(path);
            var lines = File.ReadAllLines(files[0]);

            Assert.AreEqual(9, lines.Length);
            Assert.IsTrue(lines[0].Contains("Info") && lines[0].Contains("Started file logger stream."));
            Assert.IsTrue(lines[1].Contains("Trace") && lines[1].Contains("Test Trace."));
            Assert.IsTrue(lines[2].Contains("Debug") && lines[2].Contains("Test Debug."));
            Assert.IsTrue(lines[3].Contains("Info") && lines[3].Contains("Test Info."));
            Assert.IsTrue(lines[4].Contains("Warning") && lines[4].Contains("Test Warning."));
            Assert.IsTrue(lines[5].Contains("Error") && lines[5].Contains("Test Error."));
            Assert.IsTrue(lines[6].Contains("Fatal") && lines[6].Contains("Test Fatal."));
            Assert.IsTrue(lines[7].Contains("Info") && lines[7].Contains("Test Info Equality."));
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }
    }
}
