using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.SocialMediaDtos;

namespace SignalRWebUI.Controllers
{
	public class SocialMediaController : Controller
	{
		private readonly IConsumeGenericMethod _consumeGenericMethod;

		public SocialMediaController(IConsumeGenericMethod consumeGenericMethod)
		{
			_consumeGenericMethod = consumeGenericMethod;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _consumeGenericMethod.GetConsume<List<ResultSocialMediaDto>>("http://localhost:7052/api/SocialMedia");
			if (values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateSocialMedia()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
		{
			var values = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/SocialMedia", createSocialMediaDto);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteSocialMedia(int id)
		{
			var values = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/SocialMedia", id);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateSocialMedia(int id)
		{
			var value = await _consumeGenericMethod.GetConsume<UpdateSocialMediaDto>("http://localhost:7052/api/SocialMedia", id);
			if (value != null)
			{
				return View(value);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
		{
			var value = await _consumeGenericMethod.UpdateConsume("http://localhost:7052/api/SocialMedia", updateSocialMediaDto);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
