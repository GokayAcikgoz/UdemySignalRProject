using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.MenuTableDtos;

namespace SignalRWebUI.Controllers
{
	public class MenuTableController : Controller
	{
		private readonly IConsumeGenericMethod _consumeGenericMethod;

		public MenuTableController(IConsumeGenericMethod consumeGenericMethod)
		{
			_consumeGenericMethod = consumeGenericMethod;
		}
		public async Task<IActionResult> Index()
		{

			var values = await _consumeGenericMethod.GetConsume<List<ResultMenuTableDto>>("http://localhost:7052/api/MenuTables");
			if (values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateMenuTable()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			var value = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/MenuTables", createMenuTableDto);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteMenuTable(int id)
		{

			var value = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/MenuTables", id);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateMenuTable(int id)
		{
			var values = await _consumeGenericMethod.GetConsume<UpdateMenuTableDto>("http://localhost:7052/api/MenuTables", id);
			if (values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			var values = await _consumeGenericMethod.UpdateConsume("http://localhost:7052/api/MenuTables/", updateMenuTableDto);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> TableListByStatus()
		{

			var values = await _consumeGenericMethod.GetConsume<List<ResultMenuTableDto>>("http://localhost:7052/api/MenuTables");
			if (values != null)
			{
				return View(values);
			}
			return View();
		}
	}
}
