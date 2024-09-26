using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace QuantoCusta.BlazorApp.Layout
{
	public partial class MainLayout
	{
		[Inject]
		private ILocalStorageService LocalStorageService { get; set; }

		private bool Swap { get; set; } = true;

		private bool DrawerOpen { get; set; } = true;

		private bool _darkModeThemeEnabled;

		public bool DarkModeThemeEnabled
		{
			get => _darkModeThemeEnabled;
			set => SaveDarkMode(_darkModeThemeEnabled = value).GetAwaiter();
		}

		protected override async Task OnParametersSetAsync()
		{
			await base.OnParametersSetAsync();

			if (await LocalStorageService.ContainKeyAsync("DarkModeThemeEnabled"))
				DarkModeThemeEnabled = await LocalStorageService.GetItemAsync<bool>("DarkModeThemeEnabled");

			StateHasChanged();
		}

		public void NotifyChange(long documento)
		{
			Swap = !Swap;
			StateHasChanged();
		}

		private void DrawerToggle() => DrawerOpen = !DrawerOpen;

		private async Task SaveDarkMode(bool darkModeThemeEnabled) => await LocalStorageService.SetItemAsync("DarkModeThemeEnabled", darkModeThemeEnabled);
	}
}