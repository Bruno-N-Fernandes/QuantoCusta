using Microsoft.AspNetCore.Components;
using QuantoCusta.BlazorApp.Code;

namespace QuantoCusta.BlazorApp.Pages
{
	[Route("/configuracao")]
	public partial class ConfiguracaoPage
	{
		[Inject]
		private Repositorio Repositorio { get; set; }

		private Configuracao Configuracao => Repositorio.Configuracao;
	}
}