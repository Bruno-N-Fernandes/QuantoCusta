using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;

namespace QuantoCusta.BlazorApp.Components
{
	public partial class MudDropDown<T>
	{
		[Parameter]
		public IEnumerable<T> DataSource { get; set; }

		[Parameter]
		public Func<T, string> GetText { get; set; } = x => x.ToString();

		[Parameter]
		public RenderFragment ChildContent {  get; set; }

		[Parameter(CaptureUnmatchedValues = true)]
		public Dictionary<string, object> AdditionalAttributes { get; set; }

		[Parameter]
		public T Value { get; set; }

		[Parameter]
		public EventCallback<IEnumerable<T>> SelectedValuesChanged { get; set; }

		[Parameter]
		public string Label { get; set; }

		[Parameter]
		public bool Clearable { get; set; }

	}
}