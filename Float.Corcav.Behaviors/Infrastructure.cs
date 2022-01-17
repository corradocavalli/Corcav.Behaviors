using System;

namespace Corcav.Behaviors
{
    /// <summary>
    /// Forces iOS linker to include Xamarin Behaviors assembly in deployed package.
    /// </summary>
    public static class Infrastructure
    {
#pragma warning disable IDE0052 // Remove unread private members
        static DateTime initDate;
#pragma warning restore IDE0052 // Remove unread private members

        /// <summary>
        /// Initialize this instance.
        /// </summary>
        public static void Init()
        {
            initDate = DateTime.UtcNow;
        }
    }
}
