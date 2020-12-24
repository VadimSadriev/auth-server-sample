﻿using System.IO;
using AuthServerEfCore.DataLayer.Core;
using Microsoft.EntityFrameworkCore;

namespace AuthServerEfCore.DataLayer
{
    /// <summary>
    /// Design time factory for <see cref="DataContext"/>
    /// </summary>
    public class DataContextDesignTimeFactory : DesignTimeDbContextFactory<DataContext>
    {
        protected override string AppSettingsPath => $"{Directory.GetCurrentDirectory()}/../AuthServerEfCore.Web";

        protected override string ConfigurationName => "Database:ConnectionStrings:Users";

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public override DataContext CreateContext(DbContextOptions<DataContext> options)
        {
            return new DataContext(options);
        }
    }
}