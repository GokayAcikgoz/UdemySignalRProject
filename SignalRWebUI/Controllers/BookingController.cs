using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Core;
using SignalRWebUI.Dtos.BookingDtos;

namespace SignalRWebUI.Controllers
{
	public class BookingController : Controller
	{
		private readonly IConsumeGenericMethod _consumeGenericMethod;

		public BookingController(IConsumeGenericMethod consumeGenericMethod)
		{
			_consumeGenericMethod = consumeGenericMethod;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _consumeGenericMethod.GetConsume<List<ResultBookingDto>>("http://localhost:7052/api/Bookings");
			if(values != null)
			{
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateBooking()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
		{
			var values = await _consumeGenericMethod.CreateConsume("http://localhost:7052/api/Bookings", createBookingDto);
			if (values)
			{
				return RedirectToAction("Index");	
			}
			return View();
		}

		public async Task<IActionResult> DeleteBooking(int id)
		{
			var values = await _consumeGenericMethod.DeleteConsume("http://localhost:7052/api/Bookings", id);
			if (values)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateBooking(int id)
		{
			var value = await _consumeGenericMethod.GetConsume<UpdateBookingDto>("http://localhost:7052/api/Bookings", id);
			if(value != null)
			{
				return View(value);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			var value = await _consumeGenericMethod.UpdateConsume("http://localhost:7052/api/Bookings", updateBookingDto);
			if (value)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> BookingStatusApproved(int id)
		{
			await _consumeGenericMethod.GetConsume<List<ResultBookingDto>>("http://localhost:7052/api/Bookings/BookingStatusApproved", id);

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> BookingStatusCancelled(int id)
		{
			await _consumeGenericMethod.GetConsume<List<ResultBookingDto>>("http://localhost:7052/api/Bookings/BookingStatusCancelled", id);

			return RedirectToAction("Index");
		}
	}
}
