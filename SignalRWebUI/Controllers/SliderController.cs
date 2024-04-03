using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.FeatureDtos;
using SignalRWebUI.Dtos.SliderDtos;

namespace SignalRWebUI.Controllers
{
	public class SliderController : Controller
	{
		private readonly IConsumeGenericMethod _consumeGenericMethod;

		public SliderController(IConsumeGenericMethod consumeGenericMethod)
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

			var values = await _consumeGenericMethod.GetConsume<List<ResultSliderDto>>("http://localhost:7052/api/Sliders");
			if (values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateSlider()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
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
			var value = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Sliders", createSliderDto);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteSlider(int id)
		{
			//var client = _httpClientFactory.CreateClient();
			//var responseMessage = await client.DeleteAsync($"http://localhost:7052/api/Abouts/{id}");
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//	return RedirectToAction("Index");
			//}
			//return View();
			var value = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/Sliders", id);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateSlider(int id)
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
			var values = await _consumeGenericMethod.GetConsume<UpdateFeatureDto>("http://localhost:7052/api/Sliders", id);
			if (values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
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
			var values = await _consumeGenericMethod.UpdateConsume("http://localhost:7052/api/Sliders/", updateSliderDto);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
