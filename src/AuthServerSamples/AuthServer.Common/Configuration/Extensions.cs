using System;
using Microsoft.Extensions.Configuration;

namespace AuthServer.Common.Configuration
{
    /// <summary>
    /// Extension methods for Configuration
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Checks existence of configuration section
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown if configuration does not exist </exception>
        public static IConfigurationSection EnsureExistence(this IConfigurationSection configurationSection)
        {
            if (!configurationSection.Exists())
                throw new ArgumentNullException(nameof(configurationSection), $"Configuration {configurationSection.Path} does not exist");

            return configurationSection;
        }
    }
}