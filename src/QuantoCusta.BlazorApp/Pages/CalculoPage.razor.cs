using Microsoft.AspNetCore.Components;
using QuantoCusta.BlazorApp.Code;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantoCusta.BlazorApp.Pages
{
	[Route("/calcular")]
	public partial class CalculoPage
	{
		[Inject]
		private Repositorio Repositorio { get; set; }

		private Configuracao Configuracao => Repositorio.Configuracao;

		private Profissao Profissao { get; set; }

		private CalculoCusto CalculoCusto { get; set; }

		private bool ShowAll { get; set; }

		private void NotifyChange(IEnumerable<Profissao> profissao)
		{
			CalculoCusto = new CalculoCusto(Configuracao, Profissao);
			StateHasChanged();
		}

		protected override async Task OnInitializedAsync()
		{
			Profissao = Repositorio.Profissoes.FirstOrDefault();
			CalculoCusto = new CalculoCusto(Configuracao, Profissao);
			await base.OnInitializedAsync();
		}
	}
}