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

	public static class Factory
	{
		public static IEnumerable<Config> CreateConfig()
		{
			yield return new Config
			{
				AliquotaINSS = 0.33M,
				AliquotaFGTS = 0.08M,
				AliquotaVT = 0.06M,
				PrecoPassagem = 4.30M,
			};
		}

		public static IEnumerable<Profissao> CreateProfissao()
		{
			yield return new Profissao
			{
				CBO = "1234",
				Descricao = "Atendente",
				PisoRemuneracao = 1907.49M,
				PercentualAdicionalNoturno = 1.20M,
				PercentualAdicionalPericulosidade = 1.20M,
				PercentualAdicionalInsalubridade = 1.00M,
				QuantidadeDiasExpediente = 27,
			};

			yield return new Profissao
			{
				CBO = "5678",
				Descricao = "Frentista",
				PisoRemuneracao = 1977.40M,
				PercentualAdicionalNoturno = 1.20M,
				PercentualAdicionalPericulosidade = 1.20M,
				PercentualAdicionalInsalubridade = 1.00M,
				QuantidadeDiasExpediente = 27,
			};
		}
	}
}