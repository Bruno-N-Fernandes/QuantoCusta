using System;

namespace QuantoCusta.BlazorApp.Code
{
	public class CalculoCusto
	{
		public decimal AliquotaINSS { get; set; }
		public decimal AliquotaFGTS { get; set; }
		public decimal AliquotaVT { get; set; }
		public decimal PrecoPassagem { get; set; }

		public bool TemAdicionalNoturno { get; set; }
		public bool TemAdicionalInsalubridade { get; set; }
		public bool TemAdicionalPericulosidade { get; set; }
		public bool TemAdicionalHorasExtras { get; set; }

		public decimal RemuneracaoBase { get; set; }
		public decimal QuantidadeDiasExpediente { get; set; }
		public decimal JornadaDeTrabalhoDiaria { get; set; }
		public decimal CargaHorariaMensal { get; set; }
		public TimeSpan? MediaHorasExtras { get; set; }
		public decimal QuantidadeHorasExtras => Convert.ToInt64(MediaHorasExtras?.TotalMinutes ?? 0);

		public decimal PercentualAdicionalNoturno { get; set; }
		public decimal PercentualAdicionalInsalubridade { get; set; }
		public decimal PercentualAdicionalPericulosidade { get; set; }
		public decimal PercentualAdicionalHorasExtras { get; set; }


		public decimal AdicionalNoturno => TemAdicionalNoturno ? RemuneracaoBase * PercentualAdicionalNoturno : 0;
		public decimal AdicionalInsalubridade => TemAdicionalInsalubridade ? RemuneracaoBase * PercentualAdicionalInsalubridade : 0;
		public decimal AdicionalPericulosidade => TemAdicionalPericulosidade ? RemuneracaoBase * PercentualAdicionalPericulosidade : 0;
		public decimal RemuneracaoFixa => RemuneracaoBase + AdicionalNoturno + AdicionalInsalubridade + AdicionalPericulosidade;
		public decimal ValorSalarioPorHora => RemuneracaoFixa / CargaHorariaMensal;
		public decimal ValorSalarioPorMinuto => ValorSalarioPorHora / 60;
		public decimal ValorHoraExtra => TemAdicionalHorasExtras ? (QuantidadeHorasExtras * ValorSalarioPorMinuto) : 0;
		public decimal AdicionalHorasExtras => TemAdicionalHorasExtras ? ValorHoraExtra + PercentualAdicionalHorasExtras * ValorHoraExtra : 0;

		public decimal RemuneracaoTotal => RemuneracaoFixa + AdicionalHorasExtras;

		public decimal Provisao13Salario => RemuneracaoTotal / 12M;
		public decimal ProvisaoFerias => RemuneracaoTotal / 12M;
		public decimal ProvisaoAdicionalFerias => ProvisaoFerias / 3M;
		public decimal RemuneracaoProvisao => RemuneracaoTotal + Provisao13Salario + ProvisaoFerias + ProvisaoAdicionalFerias;

		public decimal ValorINSS => RemuneracaoProvisao * AliquotaINSS;
		public decimal ValorFGTS => RemuneracaoProvisao * AliquotaFGTS;
		public decimal TransporteFuncionario => RemuneracaoTotal * AliquotaVT;
		public decimal CustoTransporte => PrecoPassagem * QuantidadeDiasExpediente * 2;
		public decimal ValorVT => Math.Max(0M, CustoTransporte - TransporteFuncionario);
		public decimal CustoTotal => RemuneracaoProvisao + ValorINSS + ValorFGTS + ValorVT;


		public CalculoCusto(Configuracao configuracao, Profissao profissao)
		{
			AliquotaINSS = configuracao.AliquotaINSS;
			AliquotaFGTS = configuracao.AliquotaFGTS;
			AliquotaVT = configuracao.AliquotaVT;
			PrecoPassagem = configuracao.PrecoPassagem;

			RemuneracaoBase = profissao.PisoSalarial;
			QuantidadeDiasExpediente = profissao.QuantidadeDiasExpediente;
			JornadaDeTrabalhoDiaria = profissao.JornadaDeTrabalhoDiaria;
			CargaHorariaMensal = profissao.CargaHorariaMensal;

			PercentualAdicionalNoturno = profissao.PercentualAdicionalNoturno;
			PercentualAdicionalInsalubridade = profissao.PercentualAdicionalInsalubridade;
			PercentualAdicionalPericulosidade = profissao.PercentualAdicionalPericulosidade;
			PercentualAdicionalHorasExtras = profissao.PercentualAdicionalHorasExtras;
		}
	}
}