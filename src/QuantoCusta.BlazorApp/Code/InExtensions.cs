using System;
using System.Linq;

namespace QuantoCusta.BlazorApp.Code
{
	public static class InExtensions
	{
		public static bool In<T>(this T self, params T[] values) => values.Contains(self);
	}
}