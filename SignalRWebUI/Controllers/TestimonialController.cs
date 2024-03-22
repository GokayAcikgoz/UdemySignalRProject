using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.TestimonialDtos;

namespace SignalRWebUI.Controllers
{
	public class TestimonialController : Controller
	{
		private readonly IConsumeGenericMethod _consumeGenericMethod;

		public TestimonialController(IConsumeGenericMethod consumeGenericMethod)
		{
			_consumeGenericMethod = consumeGenericMethod;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _consumeGenericMethod.GetConsume<List<ResultTestimonialDto>>("http://localhost:7052/api/Testimonials");
			if (values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateTestimonial()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			var values = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Testimonials", createTestimonialDto);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteTestimonial(int id)
		{
			var values = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/Testimonials", id);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateTestimonial(int id)
		{
			var value = await _consumeGenericMethod.GetConsume<UpdateTestimonialDto>("http://localhost:7052/api/Testimonials", id);
			if (value != null)
			{
				return View(value);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			var value = await _consumeGenericMethod.UpdateConsume("http://localhost:7052/api/Testimonials", updateTestimonialDto);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
