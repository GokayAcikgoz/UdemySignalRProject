using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.DiscountDtos;

namespace SignalRWebUI.Controllers
{
	public class DiscountController : Controller
	{
		private readonly IConsumeGenericMethod _consumeGenericMethod;

		public DiscountController(IConsumeGenericMethod consumeGenericMethod)
		{
			_consumeGenericMethod = consumeGenericMethod;
		}

		public async Task<IActionResult> Index()
		{
			//         var client = _httpClientFactory.CreateClient();
			//         var responseMessage = await client.GetAsync("http://localhost:7052/api/Categories");
			//         if(responseMessage.IsSuccessStatusCode)
			//         {
			//             var jsonData = await responseMessage.Content.ReadAsStringAsync();
			//             var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
			//             return View(values);
			//}
			//         return View();

			var values = await _consumeGenericMethod.GetConsume<List<ResultDiscountDto>>("http://localhost:7052/api/Discounts");
			if (values != null)
			{
				return View(values);
			}
			return View();

		}

		[HttpGet]
		public IActionResult CreateDiscount()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
		{

			//         var client = _httpClientFactory.CreateClient();
			//         var jsonData = JsonConvert.SerializeObject(createCategoryDto);
			//         StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//         var responseMessage = await client.PostAsync("http://localhost:7052/api/Categories", stringContent);
			//         if (responseMessage.IsSuccessStatusCode)
			//         {
			//             return RedirectToAction("Index");
			//         }
			//return View();

			var value = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Discounts", createDiscountDto);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteDiscount(int id)
		{
			//var client = _httpClientFactory.CreateClient();
			//var responseMessage = await client.DeleteAsync($"http://localhost:7052/api/Categories/{id}");
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//    return RedirectToAction("Index");
			//}
			//return View();

			var value = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/Discounts", id);

			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();

		}

		[HttpGet]
		public async Task<IActionResult> UpdateDiscount(int id)
		{
			//var client = _httpClientFactory.CreateClient();
			//var responseMessage = await client.GetAsync($"http://localhost:7052/api/Categories/{id}");
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//    var jsonData = await responseMessage.Content.ReadAsStringAsync();
			//    var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
			//    return View(values);
			//}
			//return View();
			var values = await _consumeGenericMethod.GetConsume<UpdateDiscountDto>("http://localhost:7052/api/Discounts", id);
			if (values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			//var client = _httpClientFactory.CreateClient();
			//var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
			//StringContent  stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//var responseMessage = await client.PutAsync("http://localhost:7052/api/Categories/", stringContent);
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//    return RedirectToAction("Index");
			//}
			//return View();
			var values = await _consumeGenericMethod.UpdateConsume("http://localhost:7052/api/Discounts/", updateDiscountDto);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {

            await _consumeGenericMethod.GetConsume<List<ResultDiscountDto>>("http://localhost:7052/api/Discounts/ChangeStatusToTrue", id);
			return RedirectToAction("Index");

        }

        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {

            await _consumeGenericMethod.GetConsume<List<ResultDiscountDto>>("http://localhost:7052/api/Discounts/ChangeStatusToTrue", id);
            return RedirectToAction("Index");

        }
    }
}
