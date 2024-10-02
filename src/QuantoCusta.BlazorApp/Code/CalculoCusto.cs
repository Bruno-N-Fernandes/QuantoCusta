using System;

namespace QuantoCusta.BlazorApp.Code
{
	public class CalculoCusto
	{
		public Profissao Profissao { get; }
		public Configuracao Configuracao { get; }

		public bool TemAdicionalNoturno { get; set; }
		public bool TemAdicionalInsalubridade { get; set; }
		public bool TemAdicionalPericulosidade { get; set; }
		public decimal RemuneracaoBase { get; set; }

		public decimal AdicionalNoturno => TemAdicionalNoturno ? RemuneracaoBase * Profissao.PercentualAdicionalNoturno : 0;
		public decimal AdicionalInsalubridade => TemAdicionalInsalubridade ? RemuneracaoBase * Profissao.PercentualAdicionalInsalubridade : 0;
		public decimal AdicionalPericulosidade => TemAdicionalPericulosidade ? RemuneracaoBase * Profissao.PercentualAdicionalPericulosidade : 0;
		public decimal RemuneracaoTotal => RemuneracaoBase + AdicionalNoturno + AdicionalInsalubridade + AdicionalPericulosidade;

		public decimal Provisao13Salario => RemuneracaoTotal / 12M;
		public decimal ProvisaoFerias => RemuneracaoTotal / 12M;
		public decimal ProvisaoAdicionalFerias => ProvisaoFerias / 3M;
		public decimal RemuneracaoProvisao => RemuneracaoTotal + Provisao13Salario + ProvisaoFerias + ProvisaoAdicionalFerias;

		public decimal ValorINSS => RemuneracaoProvisao * Configuracao.AliquotaINSS;
		public decimal ValorFGTS => RemuneracaoProvisao * Configuracao.AliquotaFGTS;
		public decimal TransporteFuncionario => RemuneracaoTotal * Configuracao.AliquotaVT;
		public decimal CustoTransporte => Configuracao.PrecoPassagem * Profissao.QuantidadeDiasExpediente * 2;
		public decimal ValorVT => Math.Max(0M, CustoTransporte - TransporteFuncionario);
		public decimal CustoTotal => RemuneracaoProvisao + ValorINSS + ValorFGTS + ValorVT;


		public CalculoCusto(Configuracao configuracao, Profissao profissao)
		{
			Configuracao = configuracao;
			Profissao = profissao;
			RemuneracaoBase = profissao.PisoSalarial;
		}
	}
}