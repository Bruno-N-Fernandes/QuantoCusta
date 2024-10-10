using System.Collections.Generic;

namespace QuantoCusta.BlazorApp.Code
{
	public static class Factory
	{
		public static IEnumerable<Configuracao> CreateConfiguracao()
		{
			yield return new Configuracao
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
				PisoSalarial = 1907.49M,
				TetoSalarial = 1907.49M,
				QuantidadeDiasExpediente = 27,
				JornadaDeTrabalhoDiaria = 8,
				CargaHorariaMensal = 220,
				PercentualAdicionalNoturno = 0.20M,
				PercentualAdicionalPericulosidade = 0.20M,
				PercentualAdicionalInsalubridade = 0.20M,
				PercentualAdicionalHorasExtras = 0.50M,
			};

			yield return new Profissao
			{
				CBO = "5678",
				Descricao = "Frentista",
				PisoSalarial = 1977.40M,
				TetoSalarial = 1977.40M,
				QuantidadeDiasExpediente = 27,
				JornadaDeTrabalhoDiaria = 8,
				CargaHorariaMensal = 220,
				PercentualAdicionalNoturno = 0.20M,
				PercentualAdicionalPericulosidade = 0.20M,
				PercentualAdicionalInsalubridade = 0.20M,
				PercentualAdicionalHorasExtras = 0.50M,
			};
		}
	}
}