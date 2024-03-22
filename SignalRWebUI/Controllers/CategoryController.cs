using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.CategoryDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConsumeGenericMethod _consumeGenericMethod;

		public CategoryController(IConsumeGenericMethod consumeGenericMethod)
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

            var values = await _consumeGenericMethod.GetConsume<List<ResultCategoryDto>>("http://localhost:7052/api/Categories");
            if (values != null)
            {
                return View(values);
            }
            return View();

		}

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
            createCategoryDto.CategoryStatus = true;

            //         var client = _httpClientFactory.CreateClient();
            //         var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            //         StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //         var responseMessage = await client.PostAsync("http://localhost:7052/api/Categories", stringContent);
            //         if (responseMessage.IsSuccessStatusCode)
            //         {
            //             return RedirectToAction("Index");
            //         }
            //return View();

            var value = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Categories", createCategoryDto);
            if(value)
            {
                return RedirectToAction("Index");
            }
            return View();
		}

        public async Task<IActionResult> DeleteCategory(int id)
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync($"http://localhost:7052/api/Categories/{id}");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View();

            var value = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/Categories", id);

            if (value)
            {
                return RedirectToAction("Index");
            }
            return View();

		}

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
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
			var values = await _consumeGenericMethod.GetConsume<UpdateCategoryDto>("http://localhost:7052/api/Categories", id);
            if (values != null)
            {
				return View(values);
			}
            return View();
		}

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
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
            var values = await _consumeGenericMethod.UpdateConsume("http://localhost:7052/api/Categories/", updateCategoryDto);
            if(values)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
	}
}
