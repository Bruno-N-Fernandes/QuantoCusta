using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using QuantoCusta.BlazorApp.Code;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuantoCusta.BlazorApp.Application
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddHttpClient("Web", client =>
			{
				var baseAddressWeb = builder.HostEnvironment.BaseAddress;
				client.BaseAddress = new Uri(baseAddressWeb);
			});

			builder.Services.AddHttpClient("Api", httpClient =>
			{
				var baseAddressApi = builder.Configuration["BaseAddressApi"];
				httpClient.BaseAddress = new Uri(baseAddressApi);
			});

			builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api"));


			builder.Services.AddSingleton<JavaScriptProxy>();
			builder.Services.AddSingleton<Sequence>();
			builder.Services.AddSingleton<Repositorio>();
			builder.Services.AddScoped<IDialogService, DialogService>();

			builder.Services.AddMudServices();
			builder.Services.AddBlazoredLocalStorage();

			var wasmHost = builder.Build();

			var repositorio = wasmHost.Services.GetRequiredService<Repositorio>();
			await repositorio.Load();

			await wasmHost.RunAsync();
		}
	}
}
