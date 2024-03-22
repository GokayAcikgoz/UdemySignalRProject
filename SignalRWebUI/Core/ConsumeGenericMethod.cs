

using Newtonsoft.Json;
using System.Text;

namespace SignalRWebUI.Core
{
	public class ConsumeGenericMethod : IConsumeGenericMethod
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ConsumeGenericMethod(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<T> GetConsume<T>(string apiUrl, int? id = null)
		{
			var client = _httpClientFactory.CreateClient();
			var url = id.HasValue ? $"{apiUrl}/{id}" : $"{apiUrl}";
			var responseMessage = await client.GetAsync(url);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<T>(jsonData);
				return values;
			}
			throw new HttpRequestException($"HTTP request failed with status code {responseMessage.StatusCode}");
		}

		public async Task<bool> DeleteConsume(string apiUrl, int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"{apiUrl}/{id}");

			return responseMessage.IsSuccessStatusCode;
        }

		public async Task<bool> CreateConsume<T>(string apiUrl, T t)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(t);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync(apiUrl, stringContent);

			return responseMessage.IsSuccessStatusCode;
		}

		public async Task<bool> UpdateConsume<T>(string apiUrl, T t)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(t);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync(apiUrl, stringContent);
			return responseMessage.IsSuccessStatusCode;
		}
	}
}
