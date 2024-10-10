using System;

namespace QuantoCusta.BlazorApp.Code
{
	public class Profissao
	{
		public string CBO { get; set; }
		public string Descricao { get; set; }
		public decimal PisoSalarial { get; set; }
		public decimal TetoSalarial { get; set; }
		public int QuantidadeDiasExpediente { get; set; }
		public int JornadaDeTrabalhoDiaria { get; set; }
		public int CargaHorariaMensal { get; set; }
		public decimal PercentualAdicionalNoturno { get; set; }
		public decimal PercentualAdicionalPericulosidade { get; set; }
		public decimal PercentualAdicionalInsalubridade { get; set; }
		public decimal PercentualAdicionalHorasExtras { get; set; }

		public void CalcularCargaHorariaMensal(string text) => CargaHorariaMensal = QuantidadeDiasExpediente * JornadaDeTrabalhoDiaria;

		public override bool Equals(object o) => (o is Profissao p) && (p?.CBO == CBO);
		public override int GetHashCode() => CBO.GetHashCode();

		public Profissao Clone() => MemberwiseClone() as Profissao;

		public void AlterarCom(Profissao profissao)
		{
			CBO = profissao.CBO;
			Descricao = profissao.Descricao;
			PisoSalarial = profissao.PisoSalarial;
			TetoSalarial = profissao.TetoSalarial;

			QuantidadeDiasExpediente = profissao.QuantidadeDiasExpediente;
			JornadaDeTrabalhoDiaria = profissao.JornadaDeTrabalhoDiaria;
			CargaHorariaMensal = profissao.CargaHorariaMensal;

			PercentualAdicionalNoturno = profissao.PercentualAdicionalNoturno;
			PercentualAdicionalPericulosidade = profissao.PercentualAdicionalPericulosidade;
			PercentualAdicionalInsalubridade = profissao.PercentualAdicionalInsalubridade;
			PercentualAdicionalHorasExtras = profissao.PercentualAdicionalHorasExtras;
		}
	}
}