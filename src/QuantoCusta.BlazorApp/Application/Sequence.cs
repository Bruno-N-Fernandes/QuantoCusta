using System.Collections.Generic;

namespace QuantoCusta.BlazorApp.Application
{
	public class Sequence
	{
		private readonly Dictionary<string, int> _sequences = new Dictionary<string, int>();

		public int NextValueFor(string sequenceName)
		{
			var value = GetValueFor(sequenceName);
			return _sequences[sequenceName] = value + 1;
		}

		public int GetValueFor(string sequenceName)
			=> _sequences.TryGetValue(sequenceName, out var value) ? value : 0;
	}
}