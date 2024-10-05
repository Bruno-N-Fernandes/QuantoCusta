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

		public decimal RemuneracaoBase { get; set; }
		public decimal PercentualAdicionalNoturno { get; set; }
		public decimal PercentualAdicionalInsalubridade { get; set; }
		public decimal PercentualAdicionalPericulosidade { get; set; }
		public decimal QuantidadeDiasExpediente { get; set; }

		public decimal AdicionalNoturno => TemAdicionalNoturno ? RemuneracaoBase * PercentualAdicionalNoturno : 0;
		public decimal AdicionalInsalubridade => TemAdicionalInsalubridade ? RemuneracaoBase * PercentualAdicionalInsalubridade : 0;
		public decimal AdicionalPericulosidade => TemAdicionalPericulosidade ? RemuneracaoBase * PercentualAdicionalPericulosidade : 0;
		public decimal RemuneracaoTotal => RemuneracaoBase + AdicionalNoturno + AdicionalInsalubridade + AdicionalPericulosidade;

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
			PercentualAdicionalNoturno = profissao.PercentualAdicionalNoturno;
			PercentualAdicionalInsalubridade = profissao.PercentualAdicionalInsalubridade;
			PercentualAdicionalPericulosidade = profissao.PercentualAdicionalPericulosidade;
			QuantidadeDiasExpediente = profissao.QuantidadeDiasExpediente;
		}
	}
}