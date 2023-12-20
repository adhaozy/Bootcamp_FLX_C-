using NLog;
using NLog.Config;

class Program
{
    static void Main(string[] args)
    {
        // Load the NLog configuration from a different file
        var currentDirectory = Directory.GetCurrentDirectory();
        var nlogConfigPath = Path.Combine(currentDirectory, "nlog.config");
			LogManager.LoadConfiguration(nlogConfigPath);

        // Use NLog as usual
        var logger = LogManager.GetCurrentClassLogger();
        logger.Info("Hello, world!");
    }
}
