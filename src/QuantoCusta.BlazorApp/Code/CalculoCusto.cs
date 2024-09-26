using System;

namespace QuantoCusta.BlazorApp.Code
{
	public class CalculoCusto
	{
		public Profissao Profissao { get; }
		public Config Config { get; }

		public decimal Remuneracao => Profissao.PisoRemuneracao * Profissao.PercentualAdicionalNoturno;
		public decimal Provisao13Salario => Remuneracao / 12M;
		public decimal ProvisaoFerias => Remuneracao / 12M;
		public decimal ProvisaoAdicionalFerias => ProvisaoFerias / 3M;

		public decimal RemuneracaoProvisao => Remuneracao + Provisao13Salario + ProvisaoFerias + ProvisaoAdicionalFerias;
		public decimal ValorINSS => RemuneracaoProvisao * Config.AliquotaINSS;
		public decimal ValorFGTS => RemuneracaoProvisao * Config.AliquotaFGTS;
		public decimal TransporteFuncionario => Remuneracao * Config.AliquotaVT;
		public decimal CustoTransporte => Config.PrecoPassagem * Profissao.QuantidadeDiasExpediente * 2;

		public decimal ValorVT => Math.Max(0M, CustoTransporte - TransporteFuncionario);
		public decimal CustoTotal => RemuneracaoProvisao + ValorINSS + ValorFGTS + ValorVT;


		public CalculoCusto(Config config, Profissao profissao)
		{
			Config = config;
			Profissao = profissao;
		}
	}
}