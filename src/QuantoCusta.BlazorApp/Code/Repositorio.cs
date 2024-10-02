using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantoCusta.BlazorApp.Code
{
	public class Repositorio
	{
		public List<Configuracao> Configuracoes { get; } = [];
		public List<Profissao> Profissoes { get; } = [];
		public Configuracao Configuracao => Configuracoes.FirstOrDefault();

		public async Task Load()
		{
			Configuracoes.AddRange(Factory.CreateConfiguracao());
			Profissoes.AddRange(Factory.CreateProfissao());
			await Task.CompletedTask;
		}
	}
}