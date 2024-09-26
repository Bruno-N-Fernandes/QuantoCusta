using Microsoft.AspNetCore.Components;

namespace QuantoCusta.BlazorApp.Layout
{
	public partial class TopBar
	{
		[Parameter]
		public EventCallback<long> OnChange { get; set; }
	}
}