using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.AboutDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class AboutController : Controller
	{
		private readonly IConsumeGenericMethod _consumeGenericMethod;

		public AboutController(IConsumeGenericMethod consumeGenericMethod)
		{
			_consumeGenericMethod = consumeGenericMethod;
		}
		public async Task<IActionResult> Index()
		{
			//var client = _httpClientFactory.CreateClient();
			//var responseMessage = await client.GetAsync("http://localhost:7052/api/Abouts");
			//if(responseMessage.IsSuccessStatusCode)
			//{
			//	var jsonData = await responseMessage.Content.ReadAsStringAsync();
			//	var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
			//	return View(values);	
			//}
			//return View();

			var values = await _consumeGenericMethod.GetConsume<List<ResultAboutDto>>("http://localhost:7052/api/Abouts");
			if (values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateAbout()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
		{
			//var client = _httpClientFactory.CreateClient();
			//var jsonData = JsonConvert.SerializeObject(createAboutDto);
			//StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//var responseMessage = await client.PostAsync("http://localhost:7052/api/Abouts", stringContent);
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//	return RedirectToAction("Index");
			//}
			//return View();
			var value = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Abouts", createAboutDto);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteAbout(int id)
		{
			//var client = _httpClientFactory.CreateClient();
			//var responseMessage = await client.DeleteAsync($"http://localhost:7052/api/Abouts/{id}");
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//	return RedirectToAction("Index");
			//}
			//return View();
			var value = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/Abouts", id);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateAbout(int id)
		{
			//var client = _httpClientFactory.CreateClient();
			//var responseMessage = await client.GetAsync($"http://localhost:7052/api/Abouts/{id}");
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//	var jsonData = await responseMessage.Content.ReadAsStringAsync();
			//	var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
			//	return View(values);
			//}
			//return View();
			var values = await _consumeGenericMethod.GetConsume<UpdateAboutDto>("http://localhost:7052/api/Abouts", id);
			if (values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			//var client = _httpClientFactory.CreateClient();
			//var jsonData = JsonConvert.SerializeObject(updateAboutDto);
			//StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//var responseMessage = await client.PutAsync("http://localhost:7052/api/Abouts/", stringContent);
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//	return RedirectToAction("Index");
			//}
			//return View();
			var values = await _consumeGenericMethod.UpdateConsume("http://localhost:7052/api/Abouts/", updateAboutDto);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
