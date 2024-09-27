namespace QuantoCusta.BlazorApp.Code
{
	public class Profissao
	{
		public string CBO { get; set; }
		public string Descricao { get; set; }
		public decimal PisoSalarial { get; set; }
		public decimal TetoSalarial { get; set; }
		public decimal Remuneracao { get; set; }
		public decimal PercentualAdicionalNoturno { get; set; }
		public decimal PercentualAdicionalPericulosidade { get; set; }
		public decimal PercentualAdicionalInsalubridade { get; set; }
		public int QuantidadeDiasExpediente { get; set; }

		public override bool Equals(object o) => (o is Profissao p) && (p?.CBO == CBO);
		public override int GetHashCode() => CBO.GetHashCode();
	}
}