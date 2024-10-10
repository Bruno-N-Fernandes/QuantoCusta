using Microsoft.AspNetCore.Components;
using MudBlazor;
using QuantoCusta.BlazorApp.Code;
using QuantoCusta.BlazorApp.Popups;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuantoCusta.BlazorApp.Pages
{
	[Route("/profissao")]
	public partial class ProfissaoPage
	{
		[Inject]
		private Repositorio Repositorio { get; set; }

		[Inject]
		private IDialogService DialogService { get; set; }

		[Inject]
		private NavigationManager Navigation { get; set; }

		private IEnumerable<Profissao> Profissoes => Repositorio.Profissoes;

		private string _searchString;

		private Func<Profissao, bool> _quickFilter => x =>
		{
			if (string.IsNullOrWhiteSpace(_searchString))
				return true;

			if (x.CBO?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
				return true;

			if (x.Descricao?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
				return true;

			if ($"{x.CBO} {x.Descricao}".Contains(_searchString))
				return true;

			return false;
		};

		public async Task OpenPopup(Profissao profissao = null, Mode mode = Mode.Incluir)
		{
			var parameters = new DialogParameters
			{
				{ "profissao", profissao?.Clone() ?? new Profissao() },
				{ "mode", mode }
			};

			var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };
			var dialog = DialogService.Show<ProfissaoPopup>("Profissão", parameters, options);
			var result = await dialog.Result;

			if (!result.Canceled)
			{
				switch (mode)
				{
					case Mode.Incluir:
						Repositorio.Profissoes.Add(result.Data as Profissao);
						break;
					case Mode.Alterar:
						profissao.AlterarCom(result.Data as Profissao);
						break;
					case Mode.Excluir:
						Repositorio.Profissoes.Remove(profissao);
						break;
				}

				StateHasChanged();
			}
		}
	}
}