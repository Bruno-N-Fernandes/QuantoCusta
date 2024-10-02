using Microsoft.AspNetCore.Components;
using QuantoCusta.BlazorApp.Code;
using System.Linq;

namespace QuantoCusta.BlazorApp.Pages
{
	[Route("/profissao1")]
	public partial class ProfissaoPopup
	{
		[Inject]
		private Repositorio Repositorio { get; set; }

		private Profissao Profissao => Repositorio.Profissoes.FirstOrDefault();
	}
}
