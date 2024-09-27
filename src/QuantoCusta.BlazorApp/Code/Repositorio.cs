using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantoCusta.BlazorApp.Code
{
	public class Repositorio
	{
		public List<Config> Configs { get; } = [];
		public List<Profissao> Profissoes { get; } = [];
		public Config Config => Configs.FirstOrDefault();

		public async Task Load()
		{
			Configs.AddRange(Factory.CreateConfig());
			Profissoes.AddRange(Factory.CreateProfissao());
			await Task.CompletedTask;
		}
	}
}