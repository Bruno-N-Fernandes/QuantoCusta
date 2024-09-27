using MudBlazor;

namespace QuantoCusta.BlazorApp.Components
{
	public class PercentualField : MudNumericField<decimal>
	{
		private static readonly Converter<decimal?> NullableDecimalConverter = new Converter<decimal?>
		{
			SetFunc = DecimalToString,
			GetFunc = StringToDecimal,
		};

		private static readonly Converter<decimal> DecimalConverter = new Converter<decimal>
		{
			SetFunc = value => DecimalToString(value),
			GetFunc = text => StringToDecimal(text).GetValueOrDefault(0),
		};

		private static string DecimalToString(decimal? value) => $"{value:P2}";

		private static decimal? StringToDecimal(string text)
		{
			if (string.IsNullOrWhiteSpace(text) || !decimal.TryParse(text.Replace("%", "").Trim(), out var result))
				return null;

			return result / 100M;
		}

		public PercentualField()
		{
			Format = "#,##0.00%";
			Converter = DecimalConverter;
			Min = 0.0M;
			Max = 100.0M;
			Step = 0.005M;
		}
	}
}