using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corcav.Behaviors
{
	/// <summary>
	/// Forces iOS linked to include Xamarin Behaviors assembly in deployed package.
	/// </summary>
	public static class Infrastructure
	{
		private static DateTime initDate;
		public static void Init()
		{
			initDate = DateTime.UtcNow;
		}
	}
}
