using CommandLine;

namespace AuthServer.EfCoreMigrator
{
    /// <summary>
    /// CMD parameters for database migrations
    /// </summary>
    public class CmdOptions
    {
        [Option('e', "env", Required = true, HelpText = "Application environment")]
        public string Environment { get; set; }
    }
}