using Microsoft.AspNetCore.Components;
using System.Web;
using System;

namespace QuantoCusta.BlazorApp.Components
{
	public partial class MultilineString
	{
		[Parameter]
		public string Value { get; set; }

		public MarkupString Html => Value.ToMarkup();
	}

	public static class HtmlUtility
	{
		private const string HtmlEnter = "\r\n<br />";
		private const string HtmlSingleSpace = "&nbsp;";
		private const string HtmlDoubleSpace = HtmlSingleSpace + HtmlSingleSpace;
		private const string HtmlTab = HtmlDoubleSpace + HtmlDoubleSpace;

		public static MarkupString ToMarkup(this string self) => new(self?.HtmlEncode()?.TransformToHtml() ?? "");

		public static string HtmlEncode(this string self) => self == null ? self : HttpUtility.HtmlEncode(self);
		public static string TransformToHtml(this string self) => self?.ReplaceEnter()?.ReplaceDoubleSpace()?.ReplaceTab();
		public static string ReplaceEnter(this string self) => self?.ReplaceEnterRN()?.ReplaceEnterNR()?.ReplaceEnterR()?.ReplaceEnterN();
		public static string ReplaceEnterRN(this string self) => self?.Replace("\r\n", "\n");
		public static string ReplaceEnterNR(this string self) => self?.Replace("\n\r", "\n");
		public static string ReplaceEnterR(this string self) => self?.Replace("\r", "\n");
		public static string ReplaceEnterN(this string self) => self?.Replace("\n", HtmlEnter);
		public static string ReplaceDoubleSpace(this string self) => self?.Replace("  ", HtmlDoubleSpace);
		public static string ReplaceTab(this string self) => self?.Replace("\t", HtmlTab);

		public static string Break(this string texto, int tamanho, string breakingChars = null, string sufixo = "...")
		{
			if (texto.Length > tamanho)
			{
				var breakings = (breakingChars ?? "\r\n\t ,.;?!").ToCharArray();
				var posicao = (texto + " ").IndexOfAny(breakings, tamanho - 1);
				var retorno = texto.Substring(0, Math.Max(posicao, tamanho));
				return retorno + ((posicao < texto.Length) ? sufixo : string.Empty);
			}
			return texto;
		}
	}

}