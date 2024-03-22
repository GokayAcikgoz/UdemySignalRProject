using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;
using System.Text.Unicode;

namespace SignalRWebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConsumeGenericMethod _consumeGenericMethod;

		public ProductController(IHttpClientFactory httpClientFactory, IConsumeGenericMethod consumeGenericMethod)
		{
			_httpClientFactory = httpClientFactory;
			_consumeGenericMethod = consumeGenericMethod;
		}
		public async Task<IActionResult> Index()
		{
			//var client = _httpClientFactory.CreateClient();
			//var responseMessage = await client.GetAsync("http://localhost:7052/api/Products/ProductListWithCategory");
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//	var jsonData = await responseMessage.Content.ReadAsStringAsync();
			//	var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
			//	return View(values);
			//}
			//return View();
			var values = await _consumeGenericMethod.GetConsume<List<ResultProductDto>>("http://localhost:7052/api/Products/ProductListWithCategory");
			if(values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			//var client = _httpClientFactory.CreateClient();
			//var responseMessage = await client.GetAsync("http://localhost:7052/api/Categories");
			//var jsonData = await responseMessage.Content.ReadAsStringAsync();
			//var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

			var values = await _consumeGenericMethod.GetConsume<List<ResultCategoryDto>>("http://localhost:7052/api/Categories");

			if(values != null)
			{
				List<SelectListItem> categoryItems = (from x in values
													  select new SelectListItem
													  {
														  Text = x.CategoryName,
														  Value = x.CategoryID.ToString()
													  }).ToList();
				ViewBag.categoryItems = categoryItems;				
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			createProductDto.ProductStatus = true;

			//var client = _httpClientFactory.CreateClient();
			//var jsonData = JsonConvert.SerializeObject(createProductDto);
			//StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//var responseMessage = await client.PostAsync("http://localhost:7052/api/Products", stringContent);
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//	return RedirectToAction("Index");
			//}
			//return View();
			var values = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Products", createProductDto);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteProduct(int id)
		{
			//var client = _httpClientFactory.CreateClient();
			//var responseMessage = await client.DeleteAsync($"http://localhost:7052/api/Products/{id}");
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//	return RedirectToAction("Index");
			//}
			//return View();
			var values = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/Products", id);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateProduct(int id)
		{

			//var client1 = _httpClientFactory.CreateClient();
			//var responseMessage1 = await client1.GetAsync("http://localhost:7052/api/Categories");
			//var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
			//var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
			//List<SelectListItem> categoryItems = (from x in values1
			//									  select new SelectListItem
			//									  {
			//										  Text = x.CategoryName,
			//										  Value = x.CategoryID.ToString()
			//									  }).ToList();

			//ViewBag.categoryItems = categoryItems;



			//var client = _httpClientFactory.CreateClient();
			//var responseMessage = await client.GetAsync($"http://localhost:7052/api/Products/{id}");
			//if (responseMessage.IsSuccessStatusCode)
			//{
			//	var jsonData = await responseMessage.Content.ReadAsStringAsync();
			//	var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
			//	return View(values);
			//}
			//return View();

			var values = await _consumeGenericMethod.GetConsume<List<ResultCategoryDto>>("http://localhost:7052/api/Categories");

			if (values != null)
			{
				List<SelectListItem> categoryItems = (from x in values
													  select new SelectListItem
													  {
														  Text = x.CategoryName,
														  Value = x.CategoryID.ToString()
													  }).ToList();
				ViewBag.categoryItems = categoryItems;
			}

			var values1 = await _consumeGenericMethod.GetConsume<UpdateProductDto>("\"http://localhost:7052/api/Products", id);
			if(values1 != null)
			{
				return View(values1);
			}
			return View();


		}

		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			//var client = _httpClientFactory.CreateClient();
			//var jsonData = JsonConvert.SerializeObject(updateProductDto);
			//StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			//var responseMessage = await client.PostAsync("http://localhost:7052/api/Products/", stringContent);
			//         if (responseMessage.IsSuccessStatusCode)
			//         {
			//	return RedirectToAction("Index");
			//         }
			//return View();

			var values = await _consumeGenericMethod.UpdateConsume("http://localhost:7052/api/Products/", updateProductDto);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
        }
	}
}
