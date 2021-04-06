using System;
using System.Collections;

namespace AuthServer.Common.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Type"/>
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Checks if given type is a class type and not string
        /// </summary>
        public static bool IsClass(this Type type)
        {
            return type.IsClass && type != typeof(string);
        }

        /// <summary>
        /// Checks if a given type is <see cref="IEnumerable"/> and not string
        /// </summary>
        public static bool IsEnumerable(this Type type)
        {
            return type.IsClass() && type.IsAssignableTo(typeof(IEnumerable));
        }
    }
}