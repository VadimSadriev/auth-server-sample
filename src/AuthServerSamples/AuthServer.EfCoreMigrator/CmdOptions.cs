using AuthServer.EfCoreMigrator.Enums;
using CommandLine;

namespace AuthServer.EfCoreMigrator
{
    /// <summary>
    /// CMD parameters for database migrations
    /// </summary>
    public class CmdOptions
    {
        /// <summary>
        /// Connection string to database.
        /// Example -с {ConnectionString}, --connectionString {ConnectionString}, --connectionString={ConnectionString}
        /// </summary>
        [Option('c', "connectionString", Required = true, HelpText = "Connection string to database")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Context for db migration
        /// </summary>
        [Option("dbContext", Required = true, HelpText = "Db context to migrate")]
        public DbContext DbContext { get; set; }
    }
}