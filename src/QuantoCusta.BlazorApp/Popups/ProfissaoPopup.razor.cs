using Microsoft.AspNetCore.Components;
using MudBlazor;
using QuantoCusta.BlazorApp.Code;
using System.Threading.Tasks;

namespace QuantoCusta.BlazorApp.Popups
{
	public partial class ProfissaoPopup
	{
		[CascadingParameter]
		public MudDialogInstance MudDialog { get; set; }

		[Parameter]
		public Profissao Profissao { get; set; }

		[Parameter]
		public Mode Mode { get; set; }

		public async Task Incluir()
		{
			MudDialog.Close(DialogResult.Ok(Profissao));
			StateHasChanged();
			await Task.CompletedTask;
		}

		public async Task Alterar()
		{
			MudDialog.Close(DialogResult.Ok(Profissao));
			StateHasChanged();
			await Task.CompletedTask;
		}

		public async Task Excluir()
		{
			MudDialog.Close(DialogResult.Ok(Profissao));
			StateHasChanged();
			await Task.CompletedTask;
		}

		public async Task Cancelar()
		{
			MudDialog.Close(DialogResult.Cancel());
			await Task.CompletedTask;
		}
	}
}
