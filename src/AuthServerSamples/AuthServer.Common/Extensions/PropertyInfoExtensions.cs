using System.Collections;
using System.Reflection;

namespace AuthServer.Common.Extensions
{
    /// <summary>
    /// Extension method for <see cref="PropertyInfo"/>
    /// </summary>
    public static class PropertyInfoExtensions
    {
        /// <summary>
        /// Check if underlying type of property is a class and a not string
        /// </summary>
        public static bool IsClass(this PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.IsClass();
        }

        /// <summary>
        /// Checks if underlying type of property is <see cref="IEnumerable"/> and a not string
        /// </summary>
        public static bool IsEnumerable(this PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.IsClass() && propertyInfo.PropertyType.IsAssignableTo(typeof(IEnumerable));
        }
    }
}