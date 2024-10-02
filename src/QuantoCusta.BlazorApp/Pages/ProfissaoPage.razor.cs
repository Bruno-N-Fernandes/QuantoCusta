using Microsoft.AspNetCore.Components;
using QuantoCusta.BlazorApp.Code;
using System;
using System.Collections.Generic;

namespace QuantoCusta.BlazorApp.Pages
{
	[Route("/profissao")]
	public partial class ProfissaoPage
	{
		[Inject]
		private Repositorio Repositorio { get; set; }

		private IEnumerable<Profissao> Profissoes => Repositorio.Profissoes;

		private string _searchString;

		private Func<Profissao, bool> _quickFilter => x =>
		{
			if (string.IsNullOrWhiteSpace(_searchString))
				return true;

			if (x.CBO.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
				return true;

			if (x.Descricao.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
				return true;

			if ($"{x.CBO} {x.Descricao}".Contains(_searchString))
				return true;

			return false;
		};
	}
}