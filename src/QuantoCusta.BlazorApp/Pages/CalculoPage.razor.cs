using Microsoft.AspNetCore.Components;
using QuantoCusta.BlazorApp.Code;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantoCusta.BlazorApp.Pages
{
	[Route("/quantoCusta")]
	public partial class CalculoPage
	{
		[Inject]
		private Repositorio Repositorio { get; set; }

		private Profissao Profissao { get; set; }

		private CalculoCusto CalculoCusto { get; set; }

		private void NotifyChange(IEnumerable<Profissao> profissao)
		{
			CalculoCusto = new CalculoCusto(Repositorio.Config, Profissao);
			this.StateHasChanged();
		}

		protected override async Task OnInitializedAsync()
		{
			Profissao = Repositorio.Profissoes.FirstOrDefault();
			CalculoCusto = new CalculoCusto(Repositorio.Config, Profissao);
			await base.OnInitializedAsync();
		}
	}
}