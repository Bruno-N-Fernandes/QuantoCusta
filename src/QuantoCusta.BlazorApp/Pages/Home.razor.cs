using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using QuantoCusta.BlazorApp.Code;
using System.Linq;
using System.Threading.Tasks;

namespace QuantoCusta.BlazorApp.Pages
{
	[Route("/teste")]
	public partial class Home
	{
		[Inject]
		private Repositorio Repositorio { get; set; }

		public RespostaFormulario RespostaFormulario = new RespostaFormulario();
		private readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings { 
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore
		};

		public string Json => JsonConvert.SerializeObject(RespostaFormulario, Formatting.Indented, JsonSerializerSettings);

		protected override async Task OnInitializedAsync()
		{
			var formulario = Repositorio.Formularios.First();
			RespostaFormulario = formulario.Responder();


			await base.OnInitializedAsync();
		}
	}
}