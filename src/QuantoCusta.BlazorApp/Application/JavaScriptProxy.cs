using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QuantoCusta.BlazorApp.Application
{
	public class JavaScriptProxy
	{
		private readonly IJSRuntime _jsRuntime;

		public JavaScriptProxy(IJSRuntime jsRuntime) => _jsRuntime = jsRuntime;

		public async Task BlazorDownloadFile<TObject>(string fileName, TObject @object, string contentType = "application/json")
		{
			var jsonString = JsonConvert.SerializeObject(@object, Formatting.Indented);
			await BlazorDownloadFile(fileName: fileName, stringContent: jsonString, contentType: contentType);
		}

		public async Task BlazorDownloadFile(string fileName, string stringContent, string contentType = "text/plain")
		{
			var content = Encoding.UTF8.GetBytes(stringContent);
			await BlazorDownloadFile(fileName: fileName, content: content, contentType: contentType);
		}

		public async Task BlazorDownloadFile(FileInfo fileInfo, string contentType, string fileName = null)
		{
			using var stream = fileInfo.OpenRead();
			await BlazorDownloadFile(fileName: fileName ?? fileInfo.Name, stream: stream, contentType: contentType);
		}

		public async Task BlazorDownloadFile(string fileName, Stream stream, string contentType)
		{
			using var memoryStream = new MemoryStream();
			stream.CopyTo(memoryStream);
			var content = memoryStream.ToArray();
			await BlazorDownloadFile(fileName: fileName, content: content, contentType: contentType);
		}

		public async Task BlazorDownloadFile(byte[] content, string contentType, string fileName)
		{
			await _jsRuntime.InvokeVoidAsync("blazorDownloadFileNet50", fileName, contentType, content);
		}
	}
}