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

		private Config Config => Repositorio.Config;

		private Profissao Profissao { get; set; }

		private CalculoCusto CalculoCusto { get; set; }

		private bool ShowAll { get; set; }

		private bool _expandedConfig = false;

		private bool _expandedProfissao = false;

		private void OnExpandCollapseConfigClick()
		{
			_expandedConfig = !_expandedConfig;
		}
		private void OnExpandCollapseProfissaoClick()
		{
			_expandedProfissao = !_expandedProfissao;
		}

		private void NotifyChange(IEnumerable<Profissao> profissao)
		{
			CalculoCusto = new CalculoCusto(Config, Profissao);
			StateHasChanged();
		}

		protected override async Task OnInitializedAsync()
		{
			Profissao = Repositorio.Profissoes.FirstOrDefault();
			CalculoCusto = new CalculoCusto(Config, Profissao);
			await base.OnInitializedAsync();
		}
	}
}