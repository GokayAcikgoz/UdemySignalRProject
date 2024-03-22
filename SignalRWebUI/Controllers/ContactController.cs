using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.ContactDtos;

namespace SignalRWebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IConsumeGenericMethod _consumeGenericMethod;

		public ContactController(IConsumeGenericMethod consumeGenericMethod)
		{
			_consumeGenericMethod = consumeGenericMethod;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _consumeGenericMethod.GetConsume<List<ResultContactDto>>("http://localhost:7052/api/Contacts");
			if (values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
		{
			var values = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Contacts", createContactDto);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteContact(int id)
		{
			var values = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/Contacts", id);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateContact(int id)
		{
			var value = await _consumeGenericMethod.GetConsume<UpdateContactDto>("http://localhost:7052/api/Contacts", id);
			if(value != null)
			{
				return View(value);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
		{
			var value = await _consumeGenericMethod.UpdateConsume("http://localhost:7052/api/Contacts", updateContactDto);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
